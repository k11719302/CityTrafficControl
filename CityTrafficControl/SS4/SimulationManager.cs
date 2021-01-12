using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS4 {
	static class SimulationManager {
		private RoadMaintenanceService rms;

		public static void Init() {
			rms = new RoadMaintenanceService();
		}

		public static void SimulateTick() {
			rms.SendSchedules();
			rms.ReceiveData();
		}
	}
}
