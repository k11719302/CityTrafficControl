using CityTrafficControl.SS2.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2 {
	static class SimulationManager {
		private static List<Participant> participants;


		public static void Init() {
			participants = new List<Participant>();
			GenerateParticipants(100);
		}

		public static void SimulateTick() {
			// TODO: do everything that should be done every tick
		}


		private static void GenerateParticipants(int count) {
			throw new NotImplementedException();
		}
	}
}
