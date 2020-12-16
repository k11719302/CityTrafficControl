using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Pedestrian : Participant {
		private PublicTransportStation nextStation;
		private ParticipantSchedule schedule;
		private bool isInjured;
	}
}
