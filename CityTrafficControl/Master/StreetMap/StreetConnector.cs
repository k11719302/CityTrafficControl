﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// A point on the street map where two StreetTypes are connected to with the use of StreetEndpoints.
	/// </summary>
	public class StreetConnector {
		/// <summary>
		/// The max health a StreetConnector can have.
		/// </summary>
		public const double MAX_HEALTH = 100;


		private static int nextID;

		private int id;
		private Coordinate coordinate;
		private StreetEndpoint ep1, ep2;

		private Building building;
		private PublicTransportStation station;

		private double health;
		private double priority;


		static StreetConnector() {
			nextID = 0;
		}


		/// <summary>
		/// Creates a new StreetConnector at the given coordinate.
		/// </summary>
		/// <param name="coordinate">The position where this StreetConnector should be located</param>
		public StreetConnector(Coordinate coordinate) {
			id = NextID;
			this.coordinate = coordinate;
			building = null;
			station = null;
			health = MAX_HEALTH;
			priority = 0;
		}
		/// <summary>
		/// Creates a new StreetConnector at the given horizontal and vertical position.
		/// </summary>
		/// <param name="x">The horizontal position</param>
		/// <param name="y">The vertical position</param>
		public StreetConnector(double x, double y) : this(new Coordinate(x, y)) { }


		private static int NextID { get { return nextID++; } }


		/// <summary>
		/// Gets the id of this StreetConnector.
		/// </summary>
		public int ID { get { return id; } }
		/// <summary>
		/// Gets the coordinate of this StreetConnector.
		/// </summary>
		public Coordinate Coordinate { get { return coordinate; } }
		/// <summary>
		/// Gets the first StreetEndpoint of this StreetConnector.
		/// </summary>
		public StreetEndpoint EP1 { get { return ep1; } }
		/// <summary>
		/// Gets the second StreetEndpoint of this StreetConnector.
		/// </summary>
		public StreetEndpoint EP2 { get { return ep2; } }

		/// <summary>
		/// Gets or sets the health of this StreetConnector.
		/// </summary>
		public double Health { get { return health; } set { health = value > MAX_HEALTH ? MAX_HEALTH : value < 0 ? 0 : value; } }
		/// <summary>
		/// Gets or sets the priority of this StreetConnector to be repaired.
		/// </summary>
		public double Priority { get { return priority; } set { priority = value < 0 ? 0 : value; } }


		/// <summary>
		/// Connects the given StreetEndpoint to this StreetConnector.
		/// </summary>
		/// <param name="ep">The StreetEndpoint that should be connected</param>
		/// <returns>The result of the connection try</returns>
		public ConnectResult Connect(StreetEndpoint ep) {
			if (ep == ep1 || ep == ep2) return ConnectResult.AlreadyConnected;

			if (ep1 == null) {
				ep1 = ep;
			}
			else if (ep2 == null) {
				ep2 = ep;
			}
			else return ConnectResult.NoFreeSlot;

			return ConnectResult.Connected;
		}
		/// <summary>
		/// Connects the given Building to this StreetConnector.
		/// </summary>
		/// <param name="building">The Building that should be connected</param>
		/// <returns>The result of the connection try</returns>
		public ConnectResult Connect(Building building) {
			if (this.building == building) return ConnectResult.AlreadyConnected;

			if (this.building == null) {
				this.building = building;
			}
			else return ConnectResult.NoFreeSlot;

			return ConnectResult.Connected;
		}
		/// <summary>
		/// Connects the given PublicTransportStation to this StreetConnector.
		/// </summary>
		/// <param name="station">The PublicTransportStation that should be connected</param>
		/// <returns>The result of the connection try</returns>
		public ConnectResult Connect(PublicTransportStation station) {
			if (this.station == station) return ConnectResult.AlreadyConnected;

			if (this.station == null) {
				this.station = station;
			}
			else return ConnectResult.NoFreeSlot;

			return ConnectResult.Connected;
		}

		/// <summary>
		/// Disconnects the given StreetEndpoint from this StreetConnector.
		/// </summary>
		/// <param name="ep">The StreetEndpoint that should be disconnected</param>
		/// <returns>The result of the disconnection try</returns>
		public DisconnectResult Disconnect(StreetEndpoint ep) {
			if (ep1 == ep) {
				ep1 = null;
			}
			else if (ep2 == ep) {
				ep2 = null;
			}
			else return DisconnectResult.NotConnected;

			return DisconnectResult.Disconnected;
		}
		/// <summary>
		/// Disconnects the given Building from this StreetConnector.
		/// </summary>
		/// <param name="building">The Building that should be disconnected</param>
		/// <returns>The result of the disconnection try</returns>
		public DisconnectResult Disconnect(Building building) {
			if (this.building == building) {
				this.building = null;
			}
			else return DisconnectResult.NotConnected;

			return DisconnectResult.Disconnected;
		}
		/// <summary>
		/// Disconnects the given PublicTransportStation from this StreetConnector.
		/// </summary>
		/// <param name="station">The PublicTransportStation that should be disconnected</param>
		/// <returns>The result of the disconnection try</returns>
		public DisconnectResult Disconnect(PublicTransportStation station) {
			if (this.station == station) {
				this.station = null;
			}
			else return DisconnectResult.NotConnected;

			return DisconnectResult.Disconnected;
		}

		/// <summary>
		/// Returns all StreetConnectors that are connected to this one over a StreetType.
		/// </summary>
		/// <returns>A list of all connected StreetConnectors</returns>
		public List<StreetConnector> FindNeighbours() {
			List<StreetConnector> neighbours = new List<StreetConnector>();

			if (ep1 != null) neighbours.AddRange(ep1.FindNeighbours());
			if (ep2 != null) neighbours.AddRange(ep2.FindNeighbours());

			return neighbours;
		}

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("StreetConnector({0})", id);
		}


		/// <summary>
		/// The result of a connection try.
		/// </summary>
		public enum ConnectResult {
			Connected, AlreadyConnected, NoFreeSlot
		}
		/// <summary>
		/// The result of a disconnection try.
		/// </summary>
		public enum DisconnectResult {
			Disconnected, NotConnected
		}
	}
}
