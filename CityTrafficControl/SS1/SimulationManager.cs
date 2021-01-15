using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS1 {
	static class SimulationManager {
		// TODO: define static fields that may be useful for this subsystem
		private static TrafficControl control;
		private static TrafficLightManager lightManager;
		private static TrafficDetection detector;

		public static void Init() {
			control = TrafficControl.GetInstance;
			lightManager = TrafficLightManager.GetInstance;
			detector = TrafficDetection.GetInstance;
		}

		public static void SimulateTick() {
			// TODO: do everything that should be done every tick

		}
	}
}
