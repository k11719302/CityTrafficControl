﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class GoodsTransport : Vehicle {
		public bool hasGoodsLoaded;


		protected abstract void loadGoods();
		protected abstract void unloadGoods();
	}
}