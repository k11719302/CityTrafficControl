using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class Adult : Pedestrian {
		public void DoWork() {
			throw new NotImplementedException();
		}

		public override void SimulateTick() {
			timeBonus = timeBonus.Add(Master.SimulationManager.TickDuration);
			switch (currentRoutingState) {
				case RoutingState.Idle:
					int newId = Master.SimulationManager.Random.Next(Master.StreetMap.StreetMapManager.Data.StreetConnectorsCount);
					StartNewRoute(Master.StreetMap.StreetMapManager.Data.StreetConnectors(newId));
					Master.ReportManager.PrintDebug(this + " starting new route from " + currentConnector + " to " + goalConnector + ".");
					break;
				case RoutingState.Finished:
					Master.ReportManager.PrintDebug(this + " has reached the goal.");
					currentRoutingState = RoutingState.Idle;
					timeBonus = TimeSpan.Zero;
					break;
				default:
					break;
			}
			ExecuteRouting();
			//throw new NotImplementedException();
		}

		public override string ToString() {
			return string.Format("Adult({0})", id);
		}
	}
}
