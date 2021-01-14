using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS1 {
	static class SimulationManager {
		// TODO: define static fields that may be useful for this subsystem

		public static void Init() {
			TrafficControl control = TrafficControl.GetInstance;
			TrafficLightManager lightManager = TrafficLightManager.GetInstance;
			TrafficDetection detector = TrafficDetection.GetInstance;
		}

		public static void SimulateTick() {
			// TODO: do everything that should be done every tick

		}
	}
}
