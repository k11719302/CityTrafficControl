using CityTrafficControl.Master.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// The base class for street elements that are connected to StreetConnectors with the use of StreetEndpoints.
	/// </summary>
	public abstract class StreetType : IIDSupport {
		public const double DEFAULT_SPEED_LIMIT = 50;
		public const double USABLE_SPACE = 0.8;


		public abstract int ID { get; }


		public abstract List<StreetConnector> FindNeighbours(StreetEndpoint ep);
	}
}
