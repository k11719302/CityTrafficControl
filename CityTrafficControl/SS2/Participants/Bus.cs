using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS2.Participants {
	class Bus : PublicTransport {
		protected override void dropPassengers(PublicTransportStation station) {
			throw new NotImplementedException();
		}

		protected override void takePassengers(List<Pedestrian> newPassengers) {
			throw new NotImplementedException();
		}
	}
}
