using CityTrafficControl.Master;
using CityTrafficControl.Master.DataStructures;
using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2 {
	static class RouteManager {
		private static DateTime lastUpdateTime;
		private static Dictionary<int, BaseRoute> baseRoutes;
		private static Dictionary<int, SpecialRoute> specialRoutes;
		private static List<BaseRouteUpdate> pendingBaseRouteUpdate;


		// Static constructor
		static RouteManager() {
			DataLinker.SS2.updateBaseRoutes += DataLinker_updateBaseRoutes;
		}

		public static void updateBaseRoutes(List<BaseRouteUpdate> baseRoutesUpdates) {
			// TODO: disable auto-update-request-Timer during update

			// collect all updates into one list
			List<BaseRouteUpdate> updates = new List<BaseRouteUpdate>(pendingBaseRouteUpdate);
			updates.AddRange(baseRoutesUpdates);
			pendingBaseRouteUpdate.Clear();

			foreach (BaseRouteUpdate update in updates) {
				switch (update.updateType) {
					case BaseRouteUpdate.UpdateType.New:
						baseRoutes.Add(update.routeID, update.newBaseRoute);
						break;
					case BaseRouteUpdate.UpdateType.Delete:
						if (routeInUse(update.newBaseRoute)) {
							pendingBaseRouteUpdate.Add(update);     // handle BaseRouteUpdate later
						}
						else {
							baseRoutes.Remove(update.routeID);
						}
						break;
					case BaseRouteUpdate.UpdateType.Change:
						if (routeInUse(update.newBaseRoute)) {
							pendingBaseRouteUpdate.Add(update);     // handle BaseRouteUpdate later
						}
						else {
							BaseRoute route;
							if (!baseRoutes.TryGetValue(update.routeID, out route)) {
								throw new KeyNotFoundException("Route ID not found");
							}
							else {
								applyChangedRouteProperties(route, update.changedProperties);
							}
						}
						break;
					default:
						throw new ArgumentException("BaseRouteUpdate-Type invalid");
				}
			}

			lastUpdateTime = DateTime.Now;
			// TODO: enable auto-update-request-Timer after update
		}

		// TODO: Needs to be called if the lastUpdateTime exceeds a given threshold (use Timer/Task in Background)
		private static void requestBaseRoutes() {
			DataLinker.SS2.requestBaseRoutes();
		}

		private static bool routeInUse(BaseRoute baseRoute) {
			// TODO: check if BaseRoute is in use
			throw new NotImplementedException();
		}

		private static void applyChangedRouteProperties(BaseRoute route, List<ChangedProperty> changedProperties) {
			throw new NotImplementedException();
		}


		#region DataLinker Receive Methods
		private static void DataLinker_updateBaseRoutes(object sender, List<BaseRouteUpdate> e) {
			updateBaseRoutes(e);
		}
		#endregion
	}
}
