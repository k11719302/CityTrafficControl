using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	class ParticipantPosition : Coordinate {
		public ParticipantPosition(double x, double y) : base(x, y) { }


		/// <summary>
		/// Gets or sets the horizontal position.
		/// </summary>
		public double PosX { get { return x; } set { x = value; } }
		/// <summary>
		/// Gets ors sets the horizontal position.
		/// </summary>
		public double PosY { get { return y; } set { y = value; } }


		public static ParticipantPosition FromCoordinate(Coordinate coordinate) {
			return new ParticipantPosition(coordinate.X, coordinate.Y);
		}
	}
}
