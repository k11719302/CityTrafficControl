﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Vehicle : Participant {
		private int seatCount;
		private int priority;
	}
}