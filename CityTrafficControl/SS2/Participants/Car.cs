using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class Car : PrivateTransport {
		public override void SimulateTick() {
			throw new NotImplementedException();
		}

		protected override void DropPassengers() {
			throw new NotImplementedException();
		}

		protected override void TakePassengers(List<Pedestrian> newPassengers) {
			throw new NotImplementedException();
		}
	}
}
