using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class GoodsTransport : Vehicle {
		protected bool hasGoodsLoaded;


		public bool HasGoodsLoaded { get { return hasGoodsLoaded; } }


		protected abstract void LoadGoods();
		protected abstract void UnloadGoods();
	}
}
