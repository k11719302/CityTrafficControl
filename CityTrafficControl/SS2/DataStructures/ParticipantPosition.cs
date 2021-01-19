using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	/// <summary>
	/// Extends a normal Coordinate with setable properties.
	/// </summary>
	class ParticipantPosition : Coordinate {
		/// <summary>
		/// Creates a new ParticipantPosition.
		/// </summary>
		/// <param name="x">The horizontal position</param>
		/// <param name="y">The vertical position</param>
		public ParticipantPosition(double x, double y) : base(x, y) { }


		/// <summary>
		/// Gets or sets the horizontal position.
		/// </summary>
		public double PosX { get { return x; } set { x = value; } }
		/// <summary>
		/// Gets ors sets the horizontal position.
		/// </summary>
		public double PosY { get { return y; } set { y = value; } }


		/// <summary>
		/// Creates a new ParticipantPosition from a given Coordinate.
		/// </summary>
		/// <param name="coordinate">The Coordinate</param>
		/// <returns>The new ParticipantPosition instance</returns>
		public static ParticipantPosition FromCoordinate(Coordinate coordinate) {
			return new ParticipantPosition(coordinate.X, coordinate.Y);
		}
	}
}
