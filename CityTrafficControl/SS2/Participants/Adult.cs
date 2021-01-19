using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	/// <summary>
	/// An adult Pedestrian that is going to a random place and does work there.
	/// </summary>
	class Adult : Pedestrian {
		protected bool isWorking;
		protected TimeSpan worktime;

		
		/// <summary>
		/// Creates a new Adult.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		public Adult(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) {
			isWorking = false;
			worktime = TimeSpan.Zero;
		}
		/// <summary>
		/// Creates a new Adult.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		public Adult(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) {
			isWorking = false;
			worktime = TimeSpan.Zero;
		}


		/// <summary>
		/// Is doing work if this Adult is currently working.
		/// </summary>
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

		/// <summary>
		/// Simulates a single tick in the simulation.
		/// </summary>
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

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("Adult({0})", id);
		}
	}
}
