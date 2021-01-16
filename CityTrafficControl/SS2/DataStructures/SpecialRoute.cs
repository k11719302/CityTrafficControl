using CityTrafficControl.Master.StreetMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	class SpecialRoute {
		protected StreetConnector start;
		protected StreetConnector end;
		protected List<StreetConnector> waypoints;


		public SpecialRoute(StreetConnector start, StreetConnector end) {
			this.start = start;
			this.end = end;
			waypoints = new List<StreetConnector>();

			CalcRoute();
		}


		// Using the A* algorithm
		private void CalcRoute() {
			SortedList<double, SearchNode> openList = new SortedList<double, SearchNode>();
			List<SearchNode> closedList = new List<SearchNode>();
			SearchNode cur = new SearchNode(start, end);
			SearchNode newNode;

			openList.Add(cur.cost, cur);

			while (openList.Count > 0) {
				cur = openList.First().Value;
				openList.Remove(cur.cost);
				if (closedList.Contains(cur)) {
					continue;
				}
				if (cur.connector == end) {
					SaveWaypoints(cur.parent);
					return;
				}
				closedList.Add(cur);
				foreach (StreetConnector successor in GetSuccessors(cur)) {
					newNode = new SearchNode(cur, successor, end);
					openList.Add(newNode.cost, newNode);
				}
			}

			throw new StreetMapException("No possible route found");
		}

		private void SaveWaypoints(SearchNode cur) {
			while (cur.parent != null) {
				waypoints.Add(cur.connector);
				cur = cur.parent;
			}

			waypoints.Reverse();
		}

		private List<StreetConnector> GetSuccessors(SearchNode current) {
			return current.connector.FindNeighbours();
		}


		private class SearchNode {
			public double cost;
			public double estimate;
			public double total;
			public SearchNode parent;
			public StreetConnector connector;


			public SearchNode(SearchNode parent, StreetConnector connector, StreetConnector end) {
				this.parent = parent;
				this.connector = connector;
				cost = parent.cost + Coordinate.GetDistance(parent.connector.Coordinate, connector.Coordinate);
				estimate = Coordinate.GetDistance(connector.Coordinate, end.Coordinate);
				total = cost + estimate;
			}
			public SearchNode(StreetConnector connector, StreetConnector end) {
				parent = null;
				this.connector = connector;
				cost = 0;
				estimate = Coordinate.GetDistance(connector.Coordinate, end.Coordinate);
				total = cost + estimate;
			}
		}
	}
}
