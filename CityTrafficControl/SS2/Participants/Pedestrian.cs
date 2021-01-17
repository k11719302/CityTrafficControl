using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Pedestrian : Participant {
		protected PublicTransportStation nextStation;
		protected bool isInjured;


		public PublicTransportStation NextStation { get { return nextStation; } }
		public bool IsInjured { get { return isInjured; } }
	}
}
