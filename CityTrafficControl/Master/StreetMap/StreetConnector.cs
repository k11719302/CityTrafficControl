using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// A point on the street map where two StreetTypes are connected with the use of StreetEndpoints.
	/// </summary>
	public class StreetConnector {
		private Coordinate coordinate;
		private StreetEndpoint ep1, ep2;


		/// <summary>
		/// Creates a new StreetConnector at the given coordinate.
		/// </summary>
		/// <param name="coordinate">The position where this StreetConnector should be located</param>
		public StreetConnector(Coordinate coordinate) {
			this.coordinate = coordinate;
		}


		/// <summary>
		/// Gets the coordinate.
		/// </summary>
		public Coordinate Coordinate { get { return coordinate; } }


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
