using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	public class StreetHub : StreetType {
		private List<StreetEndpoint> connections;


		public StreetHub() {
			connections = new List<StreetEndpoint>();
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

		private StreetEndpoint FindEndpoint(StreetConnector connector) {
			foreach (StreetEndpoint ep in connections) {
				if (ep.Connector == connector) return ep;
			}
			return null;
		}
	}
}
