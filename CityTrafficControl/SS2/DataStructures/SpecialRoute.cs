using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	/// <summary>
	/// A short route that leads a Participant from the current position to the start of a BaseRoute of from the end of a BaseRoute to the goal position.
	/// In case no BaseRoute can be used this is a full route from the current position to the goal position.
	/// </summary>
	public class SpecialRoute {
		protected StreetConnector start;
		protected StreetConnector end;
		protected List<StreetConnector> waypoints;


		/// <summary>
		/// Creates a new SpecialRoute between the given StreetConnectors.
		/// </summary>
		/// <param name="start">The start StreetConnector</param>
		/// <param name="end">The end StreetConnector</param>
		public SpecialRoute(StreetConnector start, StreetConnector end) {
			this.start = start;
			this.end = end;
			waypoints = new List<StreetConnector>();

			CalcRoute();
		}


		/// <summary>
		/// Gets the start StreetConnector of this SpecialRoute.
		/// </summary>
		public StreetConnector Start { get { return start; } }
		/// <summary>
		/// Gets the end StreetConnector of this SpecialRoute.
		/// </summary>
		public StreetConnector End { get { return end; } }
		/// <summary>
		/// Gets the waypoints between start and end as list of StreetConnectors.
		/// </summary>
		public List<StreetConnector> Waypoints { get { return waypoints; } }


		// using the A* search algorithm
		private void CalcRoute() {
			List<SearchNode> openList = new List<SearchNode>();
			List<StreetConnector> closedList = new List<StreetConnector>();
			SearchNode cur = new SearchNode(start, end);
			SearchNode newNode;

			openList.Add(cur);

			while (openList.Count > 0) {
				double lowest = openList.Min(l => l.total);
				cur = openList.First(l => l.total == lowest);
				openList.Remove(cur);
				if (closedList.Contains(cur.connector)) {
					continue;
				}
				if (cur.connector == end) {
					SaveWaypoints(cur.parent);
					return;
				}
				closedList.Add(cur.connector);
				foreach (StreetConnector successor in GetSuccessors(cur)) {
					newNode = new SearchNode(cur, successor, end);
					openList.Add(newNode);
				}
			}

			throw new StreetMapException("No possible route found");
		}

		private void SaveWaypoints(SearchNode cur) {
			if (cur == null) return;
			while (cur.parent != null) {
				waypoints.Add(cur.connector);
				cur = cur.parent;
			}

			waypoints.Reverse();
		}

		private List<StreetConnector> GetSuccessors(SearchNode current) {
			return current.connector.FindNeighbours();
		}


		/// <summary>
		/// A node with the info for the A* search algorithm.
		/// </summary>
		private class SearchNode {
			/// <summary>
			/// The cost to get to this StreetConnector.
			/// </summary>
			public double cost;
			/// <summary>
			/// The estimated cost that will be needed to reach the end StreetConnector from this StreetConnector.
			/// </summary>
			public double estimate;
			/// <summary>
			/// The total cost until now.
			/// </summary>
			public double total;
			/// <summary>
			/// The previous SearchNode that lead to this one.
			/// </summary>
			public SearchNode parent;
			/// <summary>
			/// The StreetConnector this SearchNode belongs to.
			/// </summary>
			public StreetConnector connector;


			/// <summary>
			/// Creates a new SearchNode for a given StreetConnector that was found through another SearchNode.
			/// </summary>
			/// <param name="parent">The SearchNode that lead to this one</param>
			/// <param name="connector">The StreetConnector this SearchNode belongs to</param>
			/// <param name="end">The end StreetConnector which should be found a route to</param>
			public SearchNode(SearchNode parent, StreetConnector connector, StreetConnector end) {
				this.parent = parent;
				this.connector = connector;
				cost = parent.cost + Coordinate.GetDistance(parent.connector.Coordinate, connector.Coordinate);
				estimate = Coordinate.GetDistance(connector.Coordinate, end.Coordinate);
				total = cost + estimate;
			}
			/// <summary>
			/// Creates a new SearchNode for a given StreetConnector that is the first one.
			/// </summary>
			/// <param name="connector">The StreetConnector this SearchNode belongs to</param>
			/// <param name="end">The end StreetConnector which should be found a route to</param>
			public SearchNode(StreetConnector connector, StreetConnector end) {
				parent = null;
				this.connector = connector;
				cost = 0;
				estimate = Coordinate.GetDistance(connector.Coordinate, end.Coordinate);
				total = cost + estimate;
			}


			/// <summary>
			/// Returns a string representing this Object.
			/// </summary>
			/// <returns>A string representation of this Object</returns>
			public override string ToString() {
				return string.Format("SearchNode({0}, cost={1:0.##}, estimate={2:0.##}, total{3:0.##})", connector, cost, estimate, total);
			}
		}
	}
}
