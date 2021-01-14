using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	public class TramStation : PublicTransportStation {
		public TramStation(StreetConnector connector) : base(connector) {
		}
	}
}
