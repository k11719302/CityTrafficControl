using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// Represents a multi-connection between several StreetConnectors.
	/// </summary>
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


		/// <summary>
		/// Creates a new StreetHub that isn't connected to any StreetConnector initially.
		/// </summary>
		public StreetHub() {
			id = NextID;
			connections = new List<StreetEndpoint>();
			isGreenList = new SortedList<int, bool>();
			speedLimit = DEFAULT_SPEED_LIMIT;
			UpdateSpace();
		}


		private static int NextID { get { return nextID++; } }


		/// <summary>
		/// Gets the id of this StreetHub.
		/// </summary>
		public override int ID { get { return id; } }
		/// <summary>
		/// Gets a list of all connections to this StreetHub.
		/// </summary>
		public List<StreetEndpoint> Connections { get { return connections; } }
		/// <summary>
		/// Gets a list that maps a true/green or false/red value to all connected StreetConnector ids.
		/// </summary>
		public SortedList<int, bool> IsGreenList { get { return isGreenList; } }
		/// <summary>
		/// Gets the speed limit in units/s.
		/// </summary>
		public double SpeedLimit { get { return speedLimit; } set { speedLimit = value >= 0 ? value : 0; } }
		/// <summary>
		/// Gets the space of this StreetHub.
		/// </summary>
		public double Space { get { return space; } }


		/// <summary>
		/// A Participant can claim space to mark that it has entered this StreetHub.
		/// </summary>
		/// <param name="space">The amount of space that is needed</param>
		/// <returns>True if there was enough space, false otherwise</returns>
		public bool ClaimSpace(double space) {
			bool valid;

			space = this.space - space;
			if (valid = space >= 0) {
				this.space = space;
			}

			return valid;
		}
		/// <summary>
		/// A Participant can free space to mark that it has left this StreetHub.
		/// </summary>
		/// <param name="space">The amount of space that can be freed</param>
		public void FreeSpace(double space) {
			this.space += space;
		}

		/// <summary>
		/// Connects to the given StreetConnector.
		/// </summary>
		/// <param name="connector">The StreetConnector to connect to</param>
		/// <returns>True if a connection could be established, false otherwise</returns>
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

		/// <summary>
		/// Disconnects from the connected StreetConnector.
		/// </summary>
		/// <returns>True if the connection could be broken, false otherwise</returns>
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
		
		/// <summary>
		/// Returns all StreetConnectors that are connected to the assoziated StreetType, except the one connected to the given StreetEndpoint.
		/// </summary>
		/// <param name="ep">The StreetEndpoint for which the connected StreetConnectors should be searched</param>
		/// <returns>A list of all connected StreetConnectors</returns>
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

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
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
