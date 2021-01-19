using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class PublicTransport : Vehicle {
		protected List<Pedestrian> passengers;


		/// <summary>
		/// Creates a new PublicTransport.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		protected PublicTransport(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		/// <summary>
		/// Creates a new PublicTransport.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		protected PublicTransport(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		/// <summary>
		/// Gets a list of Pedestrians this PrivatTransport is currently carrying.
		/// </summary>
		public List<Pedestrian> Passengers { get { return passengers; } }


		protected abstract void DropPassengers(PublicTransportStation station);
		protected abstract void TakePassengers(List<Pedestrian> newPassengers);


		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("PublicTransport({0})", id);
		}
	}
}
