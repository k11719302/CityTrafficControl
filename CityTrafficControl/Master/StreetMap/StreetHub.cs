using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	public class StreetHub : StreetType {
		private static int nextID;

		private int id;
		private List<StreetEndpoint> connections;
		private SortedList<int, bool> isGreenList;
		private double speedLimit;
		private double space;


		static StreetHub() {
			nextID = 0;
		}


		public StreetHub() {
			id = NextID;
			connections = new List<StreetEndpoint>();
			isGreenList = new SortedList<int, bool>();
			speedLimit = DEFAULT_SPEED_LIMIT;
			UpdateSpace();
		}


		private static int NextID { get { return nextID++; } }


		public override int ID { get { return id; } }
		public List<StreetEndpoint> Connections { get { return connections; } }
		public SortedList<int, bool> IsGreenList { get { return isGreenList; } }
		/// <summary>
		/// Gets the speed limit in units/s.
		/// </summary>
		public double SpeedLimit { get { return speedLimit; } set { speedLimit = value >= 0 ? value : 0; } }
		public double Space { get { return space; } }


		public bool ClaimSpace(double space) {
			bool valid;

			space = this.space - space;
			if (valid = space >= 0) {
				this.space = space;
			}

			return valid;
		}
		public void FreeSpace(double space) {
			this.space += space;
		}

		public bool Connect(StreetConnector connector) {
			if (FindEndpoint(connector) != null) {
				return true;
			}

			StreetEndpoint ep = new StreetEndpoint(this);
			if (!ep.Connect(connector)) {
				throw new StreetMapException("Could not connect this StreetHub to the StreetConnector");
			}
			connections.Add(ep);
			isGreenList.Add(connector.ID, true);
			UpdateSpace();

			return true;
		}

		public bool Disconnect(StreetConnector connector) {
			StreetEndpoint ep = FindEndpoint(connector);
			if (ep == null) {
				return true;
			}

			if (!ep.Disconnect()) {
				throw new StreetMapException("Could not disconnect this StreetHub from the StreetConnector");
			}
			connections.Remove(ep);
			isGreenList.Remove(connector.ID);

			return true;
		}

		public override List<StreetConnector> FindNeighbours(StreetEndpoint ep) {
			List<StreetConnector> neighbours = new List<StreetConnector>();
			bool isConnected = false;

			foreach (StreetEndpoint endpoint in connections) {
				if (endpoint == ep) {
					isConnected = true;
				}
				else {
					neighbours.Add(endpoint.Connector);
				}
			}

			if (!isConnected) {
				throw new ArgumentException("The given StreetEndpoint isn't connected to this StreetHub");
			}

			return neighbours;
		}

		public override string ToString() {
			return string.Format("StreetHub({0})", id);
		}


		private StreetEndpoint FindEndpoint(StreetConnector connector) {
			foreach (StreetEndpoint ep in connections) {
				if (ep.Connector == connector) return ep;
			}
			return null;
		}

		private void UpdateSpace() {
			if (connections.Count <= 1) {
				space = 0;
				return;
			}

			StreetEndpoint root = connections.First();

			space = 0;
			foreach (StreetEndpoint ep in connections) {
				if (ep == root) continue;
				space += Coordinate.GetDistance(root.Connector.Coordinate, ep.Connector.Coordinate);
			}
			space *= USABLE_SPACE;
		}
	}
}
