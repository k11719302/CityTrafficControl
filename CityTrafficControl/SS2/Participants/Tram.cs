﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.Simulation;

namespace CityTrafficControl.SS2.Participants {
	class Tram : PublicTransport {
		protected override void dropPassengers(PublicTransportStation station) {
			throw new NotImplementedException();
		}

		protected override void SimulationManager_SimulateTick(object sender, SimulationEventArgs e) {
			throw new NotImplementedException();
		}

		protected override void takePassengers(List<Pedestrian> newPassengers) {
			throw new NotImplementedException();
		}
	}
}
