using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// A Building assoziated to a specific StreetConnector.
	/// </summary>
	public class Building {
		private static int nextID;

		private int id;
		private StreetConnector connector;


		static Building() {
			nextID = 0;
		}

		
		/// <summary>
		/// Creates a new Building and connects it to a specific StreetConnector.
		/// </summary>
		/// <param name="connector">The StreetConnector to connects this Building to</param>
		public Building(StreetConnector connector) {
			id = NextID;

			if (!Connect(connector)) {
				throw new StreetMapException("Could not connect this Building to the StreetConnector");
			}
		}


		private static int NextID { get { return nextID++; } }


		/// <summary>
		/// Gets the id of this building.
		/// </summary>
		public int ID { get { return id; } }
		/// <summary>
		/// Gets the StreetConnector to which this Building is connected.
		/// </summary>
		public StreetConnector Connector { get { return connector; } }

		/// <summary>
		/// Gets whether this Building is connected to a StreetConnector.
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
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("Building({0})", id);
		}
	}
}
