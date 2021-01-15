using CityTrafficControl.Master.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS3 {
	class ShortestBaseRoute : BaseRoute {
		public ShortestBaseRoute(StreetConnector start, StreetConnector end) : base(start, end) { }

		protected override bool CalcRoute() {
			throw new NotImplementedException();
		}
	}
}
