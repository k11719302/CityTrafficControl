using CityTrafficControl.Master;
using CityTrafficControl.Master.DataStructures;
using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2 {
	static class RouteManager {
		private static readonly TimeSpan MAX_UPDATE_TIMEOUT = TimeSpan.FromSeconds(60);

		private static DateTime lastUpdateTime;
		private static SortedDictionary<int, BaseRouteInfo> baseRoutes;
		//private static Dictionary<int, SpecialRoute> specialRoutes;
		private static List<BaseRouteUpdate> pendingBaseRouteUpdates;


		// Static constructor
		static RouteManager() {
			lastUpdateTime = DateTime.MinValue;
			baseRoutes = new SortedDictionary<int, BaseRouteInfo>();
			pendingBaseRouteUpdates = new List<BaseRouteUpdate>();

			DataLinker.SS2.updateBaseRoutes += DataLinker_UpdateBaseRoutes;
		}


		public static void CheckUpdateTimeout() {
			if ((Master.SimulationManager.CurTickTime.Subtract(lastUpdateTime).CompareTo(MAX_UPDATE_TIMEOUT)) > 0) {
				RequestBaseRoutes();
			}
		}

		public static void UpdateBaseRoutes(List<BaseRouteUpdate> baseRoutesUpdates) {
			lastUpdateTime = Master.SimulationManager.CurTickTime;

			// collect all updates into one list
			List<BaseRouteUpdate> updates = new List<BaseRouteUpdate>(pendingBaseRouteUpdates);
			updates.AddRange(baseRoutesUpdates);
			pendingBaseRouteUpdates.Clear();

			BaseRouteInfo cur;
			foreach (BaseRouteUpdate update in updates) {
				switch (update.updateType) {
					case BaseRouteUpdate.UpdateType.New:
						baseRoutes.Add(update.routeID, new BaseRouteInfo(new BaseRouteClone(update.newBaseRoute)));
						break;
					case BaseRouteUpdate.UpdateType.Delete:
						if (RouteInUse(update.routeID)) {                       // handle BaseRouteUpdate later
							baseRoutes.TryGetValue(update.routeID, out cur);    // but prehandle it
							cur.BaseRoute.IsUsable = false;
							pendingBaseRouteUpdates.Add(update);
						}
						else {
							baseRoutes.Remove(update.routeID);
						}
						break;
					case BaseRouteUpdate.UpdateType.Change:
						if (!baseRoutes.TryGetValue(update.routeID, out cur)) {
							throw new KeyNotFoundException("Route ID not found");
						}
						else {
							if (!ApplyChangedRouteProperties(cur, update.changedProperties, RouteInUse(update.routeID))) {  // test if all changes were applied
								cur.BaseRoute.IsUsable = false;
								pendingBaseRouteUpdates.Add(update);
							}
						}
						break;
					default:
						throw new ArgumentException("BaseRouteUpdate-Type invalid");
				}
			}
		}

		public static BaseRoute GetBestBaseRoute(StreetConnector start, StreetConnector end) {
			SortedList<double, BaseRoute> routes = new SortedList<double, BaseRoute>();
			BaseRoute route;
			double cost;

			foreach (BaseRouteInfo routeInfo in baseRoutes.Values) {
				route = routeInfo.BaseRoute;
				cost = route.Length;
				cost += Coordinate.GetDistance(start.Coordinate, route.Start.Coordinate);
				cost += Coordinate.GetDistance(end.Coordinate, route.End.Coordinate);
				routes.Add(cost, route);
			}

			if (routes.Count == 0) return null;

			return routes.First().Value;
		}
		public static SpecialRoute GetSpecialRoute(StreetConnector start, StreetConnector end) {
			return new SpecialRoute(start, end);
		}


		private static void RequestBaseRoutes() {
			DataLinker.SS2.requestBaseRoutes();
		}

		private static bool RouteInUse(int routeID) {
			BaseRouteInfo info;
			if (baseRoutes.TryGetValue(routeID, out info)) {
				return info.Users > 0;
			}

			return false;
		}

		private static bool ApplyChangedRouteProperties(BaseRouteInfo info, List<ChangedProperty> changedProperties, bool routeInUse) {
			bool appliedAllChanges = true;

			foreach (ChangedProperty change in changedProperties) {
				switch (change.change) {
					case ChangedProperty.Change.Nothing: break;
					case ChangedProperty.Change.IsUsable: info.BaseRoute.IsUsable = true; break;
					case ChangedProperty.Change.IsNotUsable: info.BaseRoute.IsUsable = false; break;
					default: throw new NotSupportedException("Unknown property change");
				}
			}

			return appliedAllChanges;
		}


		#region DataLinker Receive Methods
		private static void DataLinker_UpdateBaseRoutes(object sender, List<BaseRouteUpdate> e) {
			UpdateBaseRoutes(e);
		}
		#endregion
	}
}
