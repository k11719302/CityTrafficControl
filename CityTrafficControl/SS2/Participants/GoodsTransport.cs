using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class GoodsTransport : Vehicle {
		protected bool hasGoodsLoaded;


		protected GoodsTransport(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		protected GoodsTransport(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public bool HasGoodsLoaded { get { return hasGoodsLoaded; } }


		protected abstract void LoadGoods();
		protected abstract void UnloadGoods();


		public override string ToString() {
			return string.Format("GoodsTransport({0})", id);
		}
	}
}
