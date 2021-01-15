﻿using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	class BaseRoute : IIDSupport {
		private static int nextID;

		private int id;
		private StreetConnector start;
		private StreetConnector end;
		private List<StreetConnector> waypoints;

		private bool isUsabel;
		private double length;


		static BaseRoute() {
			nextID = 0;
		}


		public BaseRoute(StreetConnector start, StreetConnector end) {
			id = NextID;

			this.start = start;
			this.end = end;
			waypoints = new List<StreetConnector>();

			isUsabel = CalcRoute();
			length = CalcLength();
		}


		private static int NextID { get { return nextID++; } }


		public int ID { get { return id; } }

		public StreetConnector Start { get { return start; } }
		public StreetConnector End { get { return end; } }
		public List<StreetConnector> Waypoints { get { return waypoints; } }

		public bool IsUsable { get { return isUsabel; } }


		private bool CalcRoute() {
			throw new NotImplementedException();
		}

		private double CalcLength() {
			double length = 0;
			StreetConnector cur = start;

			foreach (StreetConnector next in waypoints) {
				length += Coordinate.GetDistance(cur.Coordinate, next.Coordinate);
				cur = next;
			}
			length += Coordinate.GetDistance(cur.Coordinate, end.Coordinate);

			return length;
		}
	}
}