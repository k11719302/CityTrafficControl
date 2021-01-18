using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class EmergencyCar : Car {
		public EmergencyCar(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		public EmergencyCar(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public void UpdatePriority() {
			throw new NotImplementedException();
		}

		public override string ToString() {
			return string.Format("EmergencyCar({0})", id);
		}
	}
}
