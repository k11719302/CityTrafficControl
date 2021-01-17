using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Vehicle : Participant {
		protected int seatCount;
		protected int priority;


		public int SeatCount { get { return seatCount; } }
		public int Priority { get { return priority; } }
	}
}
