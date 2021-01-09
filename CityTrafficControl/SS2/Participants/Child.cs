using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.SS2.Simulation;

namespace CityTrafficControl.SS2.Participants {
	class Child : Pedestrian {
		public void learn() {
			throw new NotImplementedException();
		}

		protected override void SimulationManager_SimulateTick(object sender, SimulationEventArgs e) {
			throw new NotImplementedException();
		}
	}
}
