using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	class BaseRouteUpdate {
		public readonly int routeID;
		public readonly Type updateType;
		public readonly BaseRoute newBaseRoute;
		public readonly List<ChangedProperty> changedProperties;


		public BaseRouteUpdate(int routeID, Type updateType, BaseRoute newBaseRoute, List<ChangedProperty> changedProperties) {
			this.routeID = routeID;
			this.updateType = updateType;
			this.newBaseRoute = newBaseRoute;
			this.changedProperties = changedProperties;
		}


		public enum Type {
			Add, Delete, Change
		}

		public class ChangedProperty {
			// TODO
		}
	}
}
