using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Participant {
		private double maxSpeed;
		private int routeID;
		private ParticipantPosition position;
		private double accidientRisk;
		private TrackTypes useableTracks;
		private double size;	// how many space is used by the participant


		public Participant() {
			//SimulationManager.SimulateTick += SimulationManager_SimulateTick;
		}

		//protected abstract void SimulationManager_SimulateTick(object sender, SimulationEventArgs e);
	}
}
