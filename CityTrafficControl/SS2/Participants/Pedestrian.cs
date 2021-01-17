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
					//timeBonus = TimeSpan.Zero;
					finishedRoute = true;
					break;
				default: ExecuteRouting(); break;
			}
		}
	}
}
