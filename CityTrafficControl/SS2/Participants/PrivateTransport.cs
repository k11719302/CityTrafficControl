using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class PrivateTransport : Vehicle {
		private List<Pedestrian> passengers;


		protected abstract void dropPassengers();
		protected abstract void takePassengers(List<Pedestrian> newPassengers);
	}
}
