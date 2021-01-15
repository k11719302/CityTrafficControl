using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	class BaseRouteUpdate {
		public readonly int routeID;
		public readonly UpdateType updateType;
		public readonly BaseRoute newBaseRoute;
		public readonly List<ChangedProperty> changedProperties;


		public BaseRouteUpdate(int routeID, UpdateType updateType, BaseRoute newBaseRoute, List<ChangedProperty> changedProperties) {
			this.routeID = routeID;
			this.updateType = updateType;
			this.newBaseRoute = newBaseRoute;
			this.changedProperties = changedProperties;
		}


		public enum UpdateType {
			New, Delete, Change
		}
	}
}
