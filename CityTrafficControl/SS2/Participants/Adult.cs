using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class Adult : Pedestrian {
		protected bool isWorking;
		protected TimeSpan worktime;

		
		public Adult(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) {
			isWorking = false;
			worktime = TimeSpan.Zero;
		}
		public Adult(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) {
			isWorking = false;
			worktime = TimeSpan.Zero;
		}


		public void DoWork() {
			if (isWorking) {
				worktime = worktime.Subtract(timeBonus);
				if (worktime.CompareTo(TimeSpan.Zero) < 0) {
					isWorking = false;
					Master.ReportManager.PrintDebug(string.Format("{0} finished working.", this));
				}
				timeBonus = TimeSpan.Zero;
			}
		}

		public override void SimulateTick() {
			base.SimulateTick();

			if (finishedRoute) {
				finishedRoute = false;
				isWorking = true;
				worktime = TimeSpan.FromSeconds(Master.SimulationManager.Random.Next(5, 30));
				Master.ReportManager.PrintDebug(string.Format("{0} started working for {1} seconds.", this, worktime.TotalSeconds));
			}
			DoWork();

			if (currentRoutingState == RoutingState.Idle && !isWorking) {
				currentRoutingState = RoutingState.Starting;
			}
		}

		public override string ToString() {
			return string.Format("Adult({0})", id);
		}
	}
}
