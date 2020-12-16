using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Simulation {
	static class SimulationManager {
		public static event EventHandler<SimulationEventArgs> SimulateTick;
	}
}
