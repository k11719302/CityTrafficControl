using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master {
	static class Loader {
		private static bool isLoaded;


		static Loader() {
			isLoaded = false;
		}


		public static LoadingError Load() {
			if (isLoaded) {
				return LoadingError.AlreadyLoaded;
			}
			isLoaded = true;

			// call init methods for all subsystems


			return LoadingError.NoError;
		}

		public enum LoadingError {
			NoError, AlreadyLoaded
		}
	}
}
