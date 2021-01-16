using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS1 {
	static class SimulationManager {
		private static TrafficControl control;
		private static TrafficLightManager lightManager;
		private static TrafficDetection detector;

		public static void Init() {
			control = TrafficControl.GetInstance;
			lightManager = TrafficLightManager.GetInstance;
			detector = TrafficDetection.GetInstance;
		}

		public static void SimulateTick() {
			TrafficLightManager.UpdateTrafficLights();
		}
	}
}
