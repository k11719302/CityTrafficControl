using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	abstract class BaseRoute : IIDSupport {
		private static int nextID;

		private int id;
		protected StreetConnector start;
		protected StreetConnector end;
		protected List<StreetConnector> waypoints;

		protected bool isUsabel;
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
		protected BaseRoute() { }


		private static int NextID { get { return nextID++; } }


		public int ID { get { return id; } }

		public StreetConnector Start { get { return start; } }
		public StreetConnector End { get { return end; } }
		public List<StreetConnector> Waypoints { get { return waypoints; } }

		public double Length { get { return length; } }
		public bool IsUsable { get { return isUsabel; } set { isUsabel = value; } }


		protected void CloneFrom(BaseRoute baseRoute) {
			id = baseRoute.id;
			start = baseRoute.start;
			end = baseRoute.end;
			waypoints = new List<StreetConnector>(baseRoute.waypoints);
			isUsabel = baseRoute.isUsabel;
			length = baseRoute.length;
		}

		protected abstract bool CalcRoute();

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
