using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	/// <summary>
	/// An update of a BaseRoute sent from SS3 to SS2.
	/// </summary>
	class BaseRouteUpdate {
		/// <summary>
		/// The id of the affected BaseRoute.
		/// </summary>
		public readonly int routeID;
		/// <summary>
		/// The type of update.
		/// </summary>
		public readonly UpdateType updateType;
		/// <summary>
		/// In case of sending a new BaseRoute, this is the one.
		/// </summary>
		public readonly BaseRoute newBaseRoute;
		/// <summary>
		/// In case of sending changes, the list of changes.
		/// </summary>
		public readonly List<ChangedProperty> changedProperties;


		/// <summary>
		/// Creates a new BaseRouteUpdate.
		/// </summary>
		/// <param name="routeID">The id of the affected BaseRoute</param>
		/// <param name="updateType">The type of update</param>
		/// <param name="newBaseRoute">In case of sending a new BaseRoute, this is the one</param>
		/// <param name="changedProperties">In case of sending changes, the list of changes</param>
		public BaseRouteUpdate(int routeID, UpdateType updateType, BaseRoute newBaseRoute, List<ChangedProperty> changedProperties) {
			this.routeID = routeID;
			this.updateType = updateType;
			this.newBaseRoute = newBaseRoute;
			this.changedProperties = changedProperties;
		}


		/// <summary>
		/// The different update types.
		/// </summary>
		public enum UpdateType {
			New, Delete, Change
		}
	}
}
