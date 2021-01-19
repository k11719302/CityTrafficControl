using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// An endpoint of a StreetType that can be connected to a StreetConnector.
	/// </summary>
	public class StreetEndpoint {
		private StreetType self;
		private StreetConnector connector;


		/// <summary>
		/// Creates a new StreetEndpoint that is associated with the given StreetType.
		/// </summary>
		/// <param name="self">The self StreetType that should be the parent</param>
		public StreetEndpoint(StreetType self) {
			this.self = self;
		}


		/// <summary>
		/// Gets the self StreetType that is associated with this StreetEndpoint.
		/// </summary>
		public StreetType Self { get { return self; } }
		/// <summary>
		/// Gets the StreetConnector that is connected to this StreetEndpoint.
		/// </summary>
		public StreetConnector Connector { get { return connector; } }

		/// <summary>
		/// Gets whether this StreetEndpoint is connected to a StreetConnector.
		/// </summary>
		public bool IsConnected { get { return connector != null; } }


		/// <summary>
		/// Connects to the given StreetConnector.
		/// </summary>
		/// <param name="connector">The StreetConnector to connect to</param>
		/// <returns>True if a connection could be established, false otherwise</returns>
		public bool Connect(StreetConnector connector) {
			if (IsConnected) return false;

			StreetConnector.ConnectResult result = connector.Connect(this);
			switch (result) {
				case StreetConnector.ConnectResult.Connected: this.connector = connector; return true;
				case StreetConnector.ConnectResult.AlreadyConnected: return true;
				case StreetConnector.ConnectResult.NoFreeSlot: return false;
			}

			return false;
		}
		/// <summary>
		/// Disconnects from the connected StreetConnector.
		/// </summary>
		/// <returns>True if the connection could be broken, false otherwise</returns>
		public bool Disconnect() {
			if (!IsConnected) return true;

			StreetConnector.DisconnectResult result = connector.Disconnect(this);
			switch (result) {
				case StreetConnector.DisconnectResult.Disconnected: connector = null; return true;
				case StreetConnector.DisconnectResult.NotConnected: return true;
			}

			return false;
		}

		/// <summary>
		/// Returns all StreetConnectors that are connected to the assiziated StreetType, except the one connected to this StreetEndpoint.
		/// </summary>
		/// <returns>A list of all connected StreetConnectors</returns>
		public List<StreetConnector> FindNeighbours() {
			return self.FindNeighbours(this);
		}

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("StreetEndpoint(c={0})", connector.ID);
		}
	}
}
