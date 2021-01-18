using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS2.Participants {
	class Bus : PublicTransport {
		public Bus(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		public Bus(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public override void SimulateTick() {
			throw new NotImplementedException();
		}

		public override string ToString() {
			return string.Format("Bus({0})", id);
		}

		protected override void DropPassengers(PublicTransportStation station) {
			throw new NotImplementedException();
		}

		protected override void TakePassengers(List<Pedestrian> newPassengers) {
			throw new NotImplementedException();
		}
	}
}
