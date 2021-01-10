using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master {
	static class SimulationManager {
		private static bool firstTick;

		private static DateTime lastTickTime;
		private static DateTime curTickTime;
		private static TimeSpan tickDuration;

		static SimulationManager() {
			firstTick = true;
		}

		public static DateTime LastTickTime { get { return lastTickTime; } }
		public static DateTime CurTickTime { get { return curTickTime; } }
		public static TimeSpan TickDuration { get { return tickDuration; } }

		public static void Init() {
			SS1.SimulationManager.Init();
			SS2.SimulationManager.Init();
			SS3.SimulationManager.Init();
			SS4.SimulationManager.Init();
		}

		public static void SimulateTick() {
			UpdateTimestamps();

			SS1.SimulationManager.SimulateTick();
			SS2.SimulationManager.SimulateTick();
			SS3.SimulationManager.SimulateTick();
			SS4.SimulationManager.SimulateTick();
		}

		private static void UpdateTimestamps() {
			if (firstTick) {
				firstTick = false;
				lastTickTime = DateTime.Now;
				curTickTime = lastTickTime;
				tickDuration = TimeSpan.Zero;
			}
			else {
				lastTickTime = curTickTime;
				curTickTime = DateTime.Now;
				tickDuration = curTickTime.Subtract(lastTickTime);
			}
		}
	}
}
