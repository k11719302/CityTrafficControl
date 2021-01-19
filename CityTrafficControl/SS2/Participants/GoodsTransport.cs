using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class GoodsTransport : Vehicle {
		protected bool hasGoodsLoaded;


		/// <summary>
		/// Creates a new GoodsTransport.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		protected GoodsTransport(StreetConnector position, double maxSpeed, double accidentRisk, double size) : base(position, maxSpeed, accidentRisk, size) { }
		/// <summary>
		/// Creates a new GoodsTransport.
		/// </summary>
		/// <param name="position">The initial position of this participant</param>
		/// <param name="maxSpeed">The max speed of this participant</param>
		/// <param name="accidentRisk">The risk that this participant causes an accident</param>
		/// <param name="size">The amount of space this participant uses up</param>
		protected GoodsTransport(Building position, double maxSpeed, double accidentRisk, double size) : base(position.Connector, maxSpeed, accidentRisk, size) { }


		/// <summary>
		/// Gets wheter this GoodsTransport has goods loaded.
		/// </summary>
		public bool HasGoodsLoaded { get { return hasGoodsLoaded; } }


		protected abstract void LoadGoods();
		protected abstract void UnloadGoods();


		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("GoodsTransport({0})", id);
		}
	}
}
