using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Vehicle : Participant {
		protected int seatCount;
		protected int priority;


		protected Vehicle(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		protected Vehicle(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public int SeatCount { get { return seatCount; } }
		public int Priority { get { return priority; } }


		public override string ToString() {
			return string.Format("Vehicle({0})", id);
		}
	}
}
