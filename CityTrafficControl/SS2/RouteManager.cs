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


		public static void updateBaseRoutes(List<BaseRouteUpdate> baseRoutesUpdates) {
			// TODO: disable auto-update-request-Timer during update

			// collect all updates into one list
			List<BaseRouteUpdate> updates = new List<BaseRouteUpdate>(pendingBaseRouteUpdate);
			updates.AddRange(baseRoutesUpdates);
			pendingBaseRouteUpdate.Clear();

			foreach (BaseRouteUpdate update in pendingBaseRouteUpdate) {
				switch (update.updateType) {
					case BaseRouteUpdate.Type.Add:
						baseRoutes.Add(update.routeID, update.newBaseRoute);
						break;
					case BaseRouteUpdate.Type.Delete:
						if (routeInUse(update.newBaseRoute)) {
							pendingBaseRouteUpdate.Add(update);		// handle BaseRouteUpdate later
						}
						else {
							baseRoutes.Remove(update.routeID);
						}
						break;
					case BaseRouteUpdate.Type.Change:
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
			List<BaseRouteUpdate> updates = DataLinker.SS2.requestBaseRoutes();		// TODO: DataLinker will be implemented with M3.2
			updateBaseRoutes(updates);
		}

		private static bool routeInUse(BaseRoute baseRoute) {
			// TODO: check if BaseRoute is in use
			throw new NotImplementedException();
		}

		private static void applyChangedRouteProperties(BaseRoute route, List<BaseRouteUpdate.ChangedProperty> changedProperties) {
			throw new NotImplementedException();
		}
	}
}
