using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// Represents a single street between two StreetConnectors.
	/// </summary>
	public class StreetSegment : StreetType {
		/// <summary>
		/// The default count of lanes for each side of the StreetSegment.
		/// </summary>
		public const int DEFAULT_LANES_COUNT = 1;

		private static int nextID;

		private int id;
		private StreetEndpoint ep1, ep2;
		private double length;
		private double speedLimit;
		private TimeSpan minDriveTime;
		private int lanes;
		private double space1, space2;

		private bool isUsable;


		static StreetSegment() {
			nextID = 0;
		}


		/// <summary>
		/// Creates a new StreetSegment between two StreetConnectors.
		/// </summary>
		/// <param name="c1">The first StreetConnector</param>
		/// <param name="c2">The second StreetConnector</param>
		public StreetSegment(StreetConnector c1, StreetConnector c2) {
			id = NextID;
			ep1 = new StreetEndpoint(this);
			ep2 = new StreetEndpoint(this);

			if (!ep1.Connect(c1) || !ep2.Connect(c2)) {
				throw new StreetMapException("Could not connect this StreetSegment with all StreetConnectors");
			}

			length = CalcLength();
			speedLimit = DEFAULT_SPEED_LIMIT;
			UpdateMinDriveTime();
			lanes = DEFAULT_LANES_COUNT;
			UpdateSpace();
		}


		private static int NextID { get { return nextID++; } }


		/// <summary>
		/// Gets the id of this StreetSegment.
		/// </summary>
		public override int ID { get { return id; } }
		/// <summary>
		/// Gets the first StreetEndpoint of this StreetSegment.
		/// </summary>
		public StreetEndpoint EP1 { get { return ep1; } }
		/// <summary>
		/// Gets the second StreetEndpoint of this StreetSegment.
		/// </summary>
		public StreetEndpoint EP2 { get { return ep2; } }
		/// <summary>
		/// Gets the length in units.
		/// </summary>
		public double Length { get { return length; } }
		/// <summary>
		/// Gets the speed limit in units/s.
		/// </summary>
		public double SpeedLimit { get { return speedLimit; } set { speedLimit = value >= 0 ? value : 0; UpdateMinDriveTime(); } }
		/// <summary>
		/// Gets the minimal time to drive through the whole segment.
		/// </summary>
		public TimeSpan MinDriveTime { get { return minDriveTime; } }
		/// <summary>
		/// Gets the count of lanes on each side of the StreetSegment.
		/// </summary>
		public int Lanes { get { return lanes; } }
		/// <summary>
		/// Gets the space on the first side of this StreetSegment.
		/// </summary>
		public double Space1 { get { return space1; } }
		/// <summary>
		/// Gets the space on the second side of this StreetSegment.
		/// </summary>
		public double Space2 { get { return space2; } }

		/// <summary>
		/// Gets or sets if this StreetSegment is usable.
		/// </summary>
		public bool IsUsable { get { return isUsable; } set { isUsable = value; } }

		/// <summary>
		/// A Participant can claim space to mark that it has entered this StreetSegment.
		/// </summary>
		/// <param name="direction">The direction for which the space should be claimed</param>
		/// <param name="space">The amount of space that is needed</param>
		/// <returns>True if there was enough space, false otherwise</returns>
		public bool ClaimSpace(int direction, double space) {
			bool valid;

			switch (direction) {
				case 1: space = space1 - space; if (valid = space >= 0) space1 = space; return valid;
				case 2: space = space2 - space; if (valid = space >= 0) space2 = space; return valid;
				default: throw new ArgumentOutOfRangeException("direction");
			}
		}
		/// <summary>
		/// A Participant can free space to mark that it has left this StreetSegment.
		/// </summary>
		/// <param name="direction">The direction for which the space can be freed</param>
		/// <param name="space">The amount of space that can be freed</param>
		public void FreeSpace(int direction, double space) {
			switch (direction) {
				case 1: space1 += space; return;
				case 2: space2 += space; return;
				default: throw new ArgumentOutOfRangeException("direction");
			}
		}

		/// <summary>
		/// Returns all StreetConnectors that are connected to the assoziated StreetType, except the one connected to the given StreetEndpoint.
		/// </summary>
		/// <param name="ep">The StreetEndpoint for which the connected StreetConnectors should be searched</param>
		/// <returns>A list of all connected StreetConnectors</returns>
		public override List<StreetConnector> FindNeighbours(StreetEndpoint ep) {
			List<StreetConnector> neighbours = new List<StreetConnector>();

			if (ep1 == ep) {
				neighbours.Add(ep2.Connector);
			}
			else if (ep2 == ep) {
				neighbours.Add(ep1.Connector);
			}
			else throw new ArgumentException("The given StreetEndpoint isn't connected to this StreetSegment");

			return neighbours;
		}

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("StreetSegment({0})", id);
		}


		private double CalcLength() {
			return Coordinate.GetDistance(ep1.Connector.Coordinate, ep2.Connector.Coordinate);
		}

		private void UpdateMinDriveTime() {
			minDriveTime = TimeSpan.FromSeconds(length / speedLimit);
		}
		private void UpdateSpace() {
			space1 = space2 = length * lanes * USABLE_SPACE;
		}
	}
}
