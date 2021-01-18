using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class Child : Pedestrian {
		protected bool isLearning;
		protected TimeSpan learntime;


		public Child(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) {
			isLearning = false;
			learntime = TimeSpan.Zero;
		}
		public Child(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) {
			isLearning = false;
			learntime = TimeSpan.Zero;
		}


		public void Learn() {
			if (isLearning) {
				learntime = learntime.Subtract(timeBonus);
				if (learntime.CompareTo(TimeSpan.Zero) < 0) {
					isLearning = false;
					Master.ReportManager.PrintDebug(string.Format("{0} finished learning.", this));
				}
				timeBonus = TimeSpan.Zero;
			}
		}

		public override void SimulateTick() {
			base.SimulateTick();

			if (finishedRoute) {
				finishedRoute = false;
				isLearning = true;
				learntime = TimeSpan.FromSeconds(Master.SimulationManager.Random.Next(5, 30));
				Master.ReportManager.PrintDebug(string.Format("{0} started learning for {1} seconds.", this, learntime.TotalSeconds));
			}
			Learn();

			if (currentRoutingState == RoutingState.Idle && !isLearning) {
				currentRoutingState = RoutingState.Starting;
			}
		}

		public override string ToString() {
			return string.Format("Child({0})", id);
		}
	}
}
