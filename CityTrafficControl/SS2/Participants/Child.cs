using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	/// <summary>
	/// A child Pedestrian that is going to a random place and does selflearning there.
	/// </summary>
	class Child : Pedestrian {
		protected bool isLearning;
		protected TimeSpan learntime;


		/// <summary>
		/// Creates a new Child.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		public Child(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) {
			isLearning = false;
			learntime = TimeSpan.Zero;
		}
		/// <summary>
		/// Creates a new Child.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		public Child(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) {
			isLearning = false;
			learntime = TimeSpan.Zero;
		}


		/// <summary>
		/// Is doing selflearning if this Child is currently learning.
		/// </summary>
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

		/// <summary>
		/// Simulates a single tick in the simulation.
		/// </summary>
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

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("Child({0})", id);
		}
	}
}
