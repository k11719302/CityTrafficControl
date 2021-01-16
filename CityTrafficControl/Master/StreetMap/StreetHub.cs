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


		static StreetHub() {
			nextID = 0;
		}


		public StreetHub() {
			id = NextID;
			connections = new List<StreetEndpoint>();
		}


		private static int NextID { get { return nextID++; } }


		public override int ID { get { return id; } }


		public bool Connect(StreetConnector connector) {
			if (FindEndpoint(connector) != null) {
				return true;
			}

			StreetEndpoint ep = new StreetEndpoint(this);
			if (!ep.Connect(connector)) {
				throw new StreetMapException("Could not connect this StreetHub to the StreetConnector");
			}
			connections.Add(ep);

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

			if(!isConnected) {
				throw new ArgumentException("The given StreetEndpoint isn't connected to this StreetHub");
			}

			return neighbours;
		}


		private StreetEndpoint FindEndpoint(StreetConnector connector) {
			foreach (StreetEndpoint ep in connections) {
				if (ep.Connector == connector) return ep;
			}
			return null;
		}
	}
}
