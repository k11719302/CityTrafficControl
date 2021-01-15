using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	class ChangedProperty {
		public readonly Change change;


		public ChangedProperty(Change change) {
			this.change = change;
		}


		/// <summary>
		/// What change was done to the BaseRoute.
		/// </summary>
		public enum Change {
			/// <summary>
			/// Nothing has changed.
			/// </summary>
			Nothing,
			/// <summary>
			/// This BaseRoute is now usable.
			/// </summary>
			IsUsable,
			/// <summary>
			/// This BaseRoute is no longer usable.
			/// </summary>
			IsNotUsable
		}
	}
}
