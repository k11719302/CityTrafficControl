using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class PrivateTransport : Vehicle {
		protected List<Pedestrian> passengers;


		public List<Pedestrian> Passengers { get { return passengers; } }


		protected abstract void DropPassengers();
		protected abstract void TakePassengers(List<Pedestrian> newPassengers);
	}
}
