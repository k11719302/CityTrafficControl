using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	static class StreetMapManager {
		private static bool isInitialized;


		static StreetMapManager() {
			isInitialized = false;
		}


		public static void Init() {
			if (isInitialized) {
				ReportManager.PrintError("StreetMapManager already initialized!");
				return;
			}

			isInitialized = true;
			InitStaticMap();
			ReportManager.PrintOutput("StreetMapManager initialized.");
		}

		private static void InitStaticMap() {
			throw new NotImplementedException();
		}
	}
}
