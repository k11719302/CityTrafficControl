using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	public class BusStation : PublicTransportStation {
		public BusStation(StreetConnector connector) : base(connector) {
		}
	}
}
