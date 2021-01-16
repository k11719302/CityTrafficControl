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
		private const double DEFAULT_SPEED_LIMIT = 50;
		private const int DEFAULT_LANES_COUNT = 1;
		private const double USABLE_SPACE = 0.8;

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

		}


		private static int NextID { get { return nextID++; } }


		public override int ID { get { return id; } }
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
		public int Lanes { get { return lanes; } }
		public double Space1 { get { return space1; } }
		public double Space2 { get { return space2; } }

		public bool IsUsable { get { return isUsable; } set { isUsable = value; } }


		public void ClaimSpace(int direction, double space) {
			switch (direction) {
				case 1: space1 -= space; return;
				case 2: space2 -= space; return;
				default: throw new ArgumentOutOfRangeException("direction");
			}
		}
		public void FreeSpace(int direction, double space) {
			switch (direction) {
				case 1: space1 += space; return;
				case 2: space2 += space; return;
				default: throw new ArgumentOutOfRangeException("direction");
			}
		}

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
