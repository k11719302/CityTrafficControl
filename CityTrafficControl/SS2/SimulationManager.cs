using CityTrafficControl.Master.StreetMap;
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
			// Commented out to not force an update
			//RouteManager.CheckUpdateTimeout();

			foreach (Participant p in participants) {
				p.SimulateTick();
			}
		}


		private static void GenerateParticipants(int count) {
			Participant p;
			StreetConnector c;

			for (int i = 0; i < count; i++) {
				c = StreetMapManager.Data.StreetConnectors(Master.SimulationManager.Random.Next(StreetMapManager.Data.StreetConnectorsCount));
				switch (Master.SimulationManager.Random.Next(2)) {
					case 0: p = new Adult(c, 10, 0, 1.5); break;
					case 1: p = new Child(c, 5, 0, 1); break;
					default: p = null; break;
				}
				if (p == null) {
					Master.ReportManager.PrintError("One participant failed to be created!");
				}
				else {
					participants.Add(p);
					Master.ReportManager.PrintDebug(string.Format("Created {0} at {1}.", p, p.CurrentConnector));
				}
			}
		}
	}
}
