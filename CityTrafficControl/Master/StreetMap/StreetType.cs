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
		/// <summary>
		/// The default speed limit of a StreetType.
		/// </summary>
		public const double DEFAULT_SPEED_LIMIT = 50;
		/// <summary>
		/// The proportion of space that is usable for a normal Participant.
		/// </summary>
		public const double USABLE_SPACE = 0.8;


		/// <summary>
		/// Gets the id of this StreetType.
		/// </summary>
		public abstract int ID { get; }


		/// <summary>
		/// Returns all StreetConnectors that are connected to the assoziated StreetType, except the one connected to the given StreetEndpoint.
		/// </summary>
		/// <param name="ep">The StreetEndpoint for which the connected StreetConnectors should be searched</param>
		/// <returns>A list of all connected StreetConnectors</returns>
		public abstract List<StreetConnector> FindNeighbours(StreetEndpoint ep);
	}
}
