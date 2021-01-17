using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS2.Participants {
	class Bus : PublicTransport {
		public override void SimulateTick() {
			throw new NotImplementedException();
		}

		protected override void DropPassengers(PublicTransportStation station) {
			throw new NotImplementedException();
		}

		protected override void TakePassengers(List<Pedestrian> newPassengers) {
			throw new NotImplementedException();
		}
	}
}
