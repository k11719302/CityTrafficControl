using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class Van : GoodsTransport {
		public Van(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		public Van(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public override void SimulateTick() {
			throw new NotImplementedException();
		}

		public override string ToString() {
			return string.Format("Van({0})", id);
		}

		protected override void LoadGoods() {
			throw new NotImplementedException();
		}

		protected override void UnloadGoods() {
			throw new NotImplementedException();
		}
	}
}
