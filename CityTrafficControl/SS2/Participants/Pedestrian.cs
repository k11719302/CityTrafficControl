using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	/// <summary>
	/// A basic Pedestrian that can walk and use vehicles.
	/// </summary>
	abstract class Pedestrian : Participant {
		protected bool finishedRoute;
		protected PublicTransportStation nextStation;
		protected bool isInjured;


		/// <summary>
		/// Creates a new Pedestrian.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		protected Pedestrian(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		/// <summary>
		/// Creates a new Pedestrian.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		protected Pedestrian(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		/// <summary>
		/// Gets the next PublicTransportStation where the Pedestrian needs to get of the PublicTransportVehicle.
		/// </summary>
		public PublicTransportStation NextStation { get { return nextStation; } }
		/// <summary>
		/// Gets whether this Pedestrian is injured.
		/// </summary>
		public bool IsInjured { get { return isInjured; } }


		/// <summary>
		/// Simulates a single tick in the simulation.
		/// </summary>
		public override void SimulateTick() {
			base.SimulateTick();

			switch (currentRoutingState) {
				case RoutingState.Idle: break;
				case RoutingState.Starting:
					int newId = Master.SimulationManager.Random.Next(StreetMapManager.Data.StreetConnectorsCount);
					StartNewRoute(StreetMapManager.Data.StreetConnectors(newId));
					Master.ReportManager.PrintDebug(string.Format("{0} starting new route from {1} to {2}.", this, currentConnector, goalConnector));
					ExecuteRouting();
					break;
				case RoutingState.Finished:
					Master.ReportManager.PrintDebug(string.Format("{0} has reached the goal.", this));
					currentRoutingState = RoutingState.Idle;
					finishedRoute = true;
					break;
				default: ExecuteRouting(); break;
			}
		}

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("Pedestrian({0})", id);
		}
	}
}
