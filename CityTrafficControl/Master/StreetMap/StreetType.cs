using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// The base class for street elements that are connected to StreetConnectors with the use of StreetEndpoints.
	/// </summary>
	public abstract class StreetType {
		public abstract int ID { get; }
		// TODO: Define abstract methods
	}
}
