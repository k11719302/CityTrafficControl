using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	/// <summary>
	/// Defines a route from a start StreetConnector to an end StreetConnector.
	/// The wayspoints are also StreetConnectors.
	/// </summary>
	public abstract class BaseRoute : IIDSupport {
		private static int nextID;

		private int id;
		protected StreetConnector start;
		protected StreetConnector end;
		protected List<StreetConnector> waypoints;

		protected bool isUsable;
		private double length;


		static BaseRoute() {
			nextID = 0;
		}


		/// <summary>
		/// Creates a new BaseRoute between two StreetConnectors.
		/// </summary>
		/// <param name="start">The StreetConnector from where to begin</param>
		/// <param name="end">The StreetConnector to where to end</param>
		protected BaseRoute(StreetConnector start, StreetConnector end) {
			id = NextID;

			this.start = start;
			this.end = end;
			waypoints = new List<StreetConnector>();

			isUsable = CalcRoute();
			length = CalcLength();
		}
		protected BaseRoute() { }


		private static int NextID { get { return nextID++; } }


		/// <summary>
		/// Gets the id of this BaseRoute.
		/// </summary>
		public int ID { get { return id; } }

		/// <summary>
		/// Gets the start StreetConnector of this BaseRoute.
		/// </summary>
		public StreetConnector Start { get { return start; } }
		/// <summary>
		/// Gets the end StreetConnector of this BaseRoute.
		/// </summary>
		public StreetConnector End { get { return end; } }
		/// <summary>
		/// Gets the waypoints between start and end as list of StreetConnectors.
		/// </summary>
		public List<StreetConnector> Waypoints { get { return waypoints; } }

		/// <summary>
		/// Gets the length of this BaseRoute.
		/// </summary>
		public double Length { get { return length; } }
		/// <summary>
		/// Gets or sets if this BaseRoute is usable.
		/// </summary>
		public bool IsUsable { get { return isUsable; } set { isUsable = value; } }


		protected void CloneFrom(BaseRoute baseRoute) {
			id = baseRoute.id;
			start = baseRoute.start;
			end = baseRoute.end;
			waypoints = new List<StreetConnector>(baseRoute.waypoints);
			isUsable = baseRoute.isUsable;
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
