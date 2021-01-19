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
		protected double x;
		protected double y;


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


		/// <summary>
		/// Calculates the distance between two Coordinates.
		/// </summary>
		/// <param name="c1">The first Coordinate</param>
		/// <param name="c2">The second Coordinate</param>
		/// <returns>The distance between the two Coordinates</returns>
		public static double GetDistance(Coordinate c1, Coordinate c2) {
			double diffX = c1.X - c2.X;
			double diffY = c1.Y - c2.Y;

			return Math.Sqrt(diffX * diffX + diffY * diffY);
		}


		/// <summary>
		/// Returns a string representing this Object.
		/// </summary>
		/// <returns>A string representation of this Object</returns>
		public override string ToString() {
			return string.Format("Coordinate({0}, {1})", x, y);
		}
	}
}
