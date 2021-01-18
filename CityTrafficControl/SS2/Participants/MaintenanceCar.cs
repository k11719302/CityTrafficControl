using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class MaintenanceCar : Car {
		public MaintenanceCar(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		public MaintenanceCar(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public void UpdatePriority() {
			throw new NotImplementedException();
		}

		public override string ToString() {
			return string.Format("MaintenanceCar({0})", id);
		}
	}
}
