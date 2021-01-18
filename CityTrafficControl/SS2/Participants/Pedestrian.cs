using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Pedestrian : Participant {
		protected bool finishedRoute;
		protected PublicTransportStation nextStation;
		protected bool isInjured;


		protected Pedestrian(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		protected Pedestrian(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		public PublicTransportStation NextStation { get { return nextStation; } }
		public bool IsInjured { get { return isInjured; } }


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

		public override string ToString() {
			return string.Format("Pedestrian({0})", id);
		}
	}
}
