using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	/// <summary>
	/// A single change of a BaseRoute.
	/// </summary>
	class ChangedProperty {
		/// <summary>
		/// The type of change.
		/// </summary>
		public readonly Change change;


		/// <summary>
		/// Creates a new change of a BaseRoute.
		/// </summary>
		/// <param name="change">The type of change</param>
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
