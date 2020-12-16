using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class PublicTransport : Vehicle {
		private List<Pedestrian> passengers;


		protected abstract void dropPassengers(PublicTransportStation station);
		protected abstract void takePassengers(List<Pedestrian> newPassengers);
	}
}
