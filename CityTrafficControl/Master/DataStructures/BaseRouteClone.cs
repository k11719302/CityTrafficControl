using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.Master.DataStructures {
	/// <summary>
	/// This is a clone from a BaseRoute.
	/// </summary>
	class BaseRouteClone : BaseRoute {
		/// <summary>
		/// Creates a clone of the given BaseRoute.
		/// </summary>
		/// <param name="baseRoute">The BaseRoute to clone</param>
		public BaseRouteClone(BaseRoute baseRoute) {
			CloneFrom(baseRoute);
		}

		protected override bool CalcRoute() {
			throw new InvalidOperationException("This is just a clone");
		}
	}
}
