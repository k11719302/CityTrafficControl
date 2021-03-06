﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// A public transport station, where Pedestrians can get on and off public transport vehicles.
	/// </summary>
	public abstract class PublicTransportStation {
		private static int nextID;

		private int id;
		private StreetConnector connector;


		static PublicTransportStation() {
			nextID = 0;
		}


		/// <summary>
		/// Creates a new PublicTransportStation and connects it to a specific StreetConnector.
		/// </summary>
		/// <param name="connector">The StreetConnector to where connect to</param>
		protected PublicTransportStation(StreetConnector connector) {
			id = NextID;

			if (!Connect(connector)) {
				throw new StreetMapException("Could not connect this PublicTransportStation to the StreetConnector");
			}
		}


		private static int NextID { get { return nextID++; } }


		/// <summary>
		/// Gets the id of this PublicTransportStation.
		/// </summary>
		public int ID { get { return id; } }

		/// <summary>
		/// Gets whether this PublicTransportStation is connected to a StreetConnector.
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
	}
}
