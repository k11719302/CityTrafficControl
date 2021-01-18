using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class PublicTransport : Vehicle {
		protected List<Pedestrian> passengers;


		protected PublicTransport(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		protected PublicTransport(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public List<Pedestrian> Passengers { get { return passengers; } }


		protected abstract void DropPassengers(PublicTransportStation station);
		protected abstract void TakePassengers(List<Pedestrian> newPassengers);


		public override string ToString() {
			return string.Format("PublicTransport({0})", id);
		}
	}
}
