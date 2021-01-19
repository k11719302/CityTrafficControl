using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	class Van : GoodsTransport {
		/// <summary>
		/// Creates a new Van.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		public Van(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		/// <summary>
		/// Creates a new Van.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		public Van(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		/// <summary>
		/// Simulates a single tick in the simulation.
		/// </summary>
		public override void SimulateTick() {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("Van({0})", id);
		}


		protected override void LoadGoods() {
			throw new NotImplementedException();
		}

		protected override void UnloadGoods() {
			throw new NotImplementedException();
		}
	}
}
