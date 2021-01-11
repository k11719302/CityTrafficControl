using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// A position in the world.
	/// </summary>
	public class Coordinate {
		private double x;
		private double y;


		/// <summary>
		/// Creates a new Coordinate.
		/// </summary>
		/// <param name="x">The horizontal position</param>
		/// <param name="y">The vertical position</param>
		public Coordinate(double x, double y) {
			this.x = x;
			this.y = y;
		}


		/// <summary>
		/// Gets the horizontal position.
		/// </summary>
		public double X { get { return x; } }
		/// <summary>
		/// Gets the vertical position.
		/// </summary>
		public double Y { get { return y; } }
	}
}
