using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// Denotes an error in association with the street map.
	/// </summary>
	public class StreetMapException : Exception {
		/// <summary>
		/// Creates a new StreetMapException.
		/// </summary>
		/// <param name="message">The respective error message</param>
		public StreetMapException(string message) : base(message) { }
	}
}
