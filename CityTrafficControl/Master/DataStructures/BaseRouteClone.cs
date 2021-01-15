using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.Master.DataStructures {
	class BaseRouteClone : BaseRoute {
		public BaseRouteClone(BaseRoute baseRoute) {
			CloneFrom(baseRoute);
		}

		protected override bool CalcRoute() {
			throw new InvalidOperationException("This is just a clone");
		}
	}
}
