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
			GenerateParticipants(4);
		}

		public static void SimulateTick() {
			// TODO: do everything that should be done every tick
		}


		private static void GenerateParticipants(int count) {
			Participant p;

			for (int i = 0; i < count; i++) {
				p = new Adult();
				participants.Add(p);
				Master.ReportManager.PrintDebug("DEBUG: Created Participant with ID (" + p.ID + ").");
			}
	}
}
}
