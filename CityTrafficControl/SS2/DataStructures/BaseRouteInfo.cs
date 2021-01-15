using CityTrafficControl.Master.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	class BaseRouteInfo {
		private BaseRoute baseRoute;
		private int users;


		public BaseRouteInfo(BaseRoute baseRoute) {
			this.baseRoute = baseRoute;
			users = 0;
		}


		public BaseRoute BaseRoute { get { return baseRoute; } }
		public int Users { get { return users; } set { users = value; } }
	}
}
