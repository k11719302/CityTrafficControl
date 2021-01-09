using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.SS2.Simulation;

namespace CityTrafficControl.SS2.Participants {
	class Car : PrivateTransport {
		protected override void dropPassengers() {
			throw new NotImplementedException();
		}

		protected override void SimulationManager_SimulateTick(object sender, SimulationEventArgs e) {
			throw new NotImplementedException();
		}

		protected override void takePassengers(List<Pedestrian> newPassengers) {
			throw new NotImplementedException();
		}
	}
}
