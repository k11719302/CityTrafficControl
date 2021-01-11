﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// Represents a single street between two StreetConnectors.
	/// </summary>
	public class StreetSegment : StreetType {
		private StreetEndpoint ep1, ep2;
		private double length;


		/// <summary>
		/// Creates a new StreetSegment between two StreetConnectors.
		/// </summary>
		/// <param name="c1">The first StreetConnector</param>
		/// <param name="c2">The second StreetConnector</param>
		public StreetSegment(StreetConnector c1, StreetConnector c2) {
			ep1 = new StreetEndpoint(this);
			ep2 = new StreetEndpoint(this);

			if (!ep1.Connect(c1) || !ep2.Connect(c2)) {
				throw new StreetMapException("Could not connect this StreetSegment with all StreetConnectors");
			}

			length = CalcLength();
		}


		/// <summary>
		/// Gets the length.
		/// </summary>
		public double Length { get { return length; } }


		private double CalcLength() {
			Coordinate c1 = ep1.Connector.Coordinate, c2 = ep2.Connector.Coordinate;
			double diffX = c1.X - c2.X;
			double diffY = c1.Y - c2.Y;

			return Math.Sqrt(diffX * diffX + diffY * diffY);
		}
	}
}