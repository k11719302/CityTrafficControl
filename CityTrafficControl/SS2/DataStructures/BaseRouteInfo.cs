using CityTrafficControl.Master.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	/// <summary>
	/// Stores a BaseRoute together with information for SS2.
	/// </summary>
	class BaseRouteInfo {
		private BaseRoute baseRoute;
		private int users;


		/// <summary>
		/// Creates a new BaseRouteInfo for a given BaseRoute.
		/// </summary>
		/// <param name="baseRoute">The BaseRoute</param>
		public BaseRouteInfo(BaseRoute baseRoute) {
			this.baseRoute = baseRoute;
			users = 0;
		}


		/// <summary>
		/// Gets the BaseRoute.
		/// </summary>
		public BaseRoute BaseRoute { get { return baseRoute; } }
		/// <summary>
		/// Gets or sets the count of users of this BaseRoute.
		/// </summary>
		public int Users { get { return users; } set { users = value; } }
	}
}
