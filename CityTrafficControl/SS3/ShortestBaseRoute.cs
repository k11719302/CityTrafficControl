using CityTrafficControl.Master.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS3 {
	public class ShortestBaseRoute : BaseRoute {
		public ShortestBaseRoute(StreetConnector start, StreetConnector end) : base(start, end) { }

		protected override bool CalcRoute() {
			SortedList<double, Node> pq = new SortedList<double, Node>();
			List<StreetConnector> visited = new List<StreetConnector>();
			Node cur = new Node(start, end);
			visited.Add(cur.con);
			pq.Add(cur.cost, cur);
			while(pq.Count > 0)
            {
				cur = pq.Values[0];
				pq.RemoveAt(0);

				if(cur.con == end)
                {
					CreatePath(cur);
					return true;
                }
				foreach(StreetConnector sc in cur.con.FindNeighbours())
                {
                    if (!visited.Contains(sc))
                    {
						Node n = new Node(cur, sc, end);
						pq.Add(n.cost, n);
						visited.Add(sc);
                    }
                }
            }
			return false;
		}

		private void CreatePath(Node cur)
		{
			while (cur.pre != null)
            {
				waypoints.Add(cur.con);
				cur = cur.pre;
            }
			waypoints.Reverse();
		}


		private class Node
        {
			public Node pre;
			public StreetConnector con;
			public double cost;

			public Node(StreetConnector con, StreetConnector end)
            {
				pre = null;
				this.con = con;
				cost = 0;
            }

			public Node(Node pre, StreetConnector con, StreetConnector end)
			{
				this.pre = pre;
				this.con = con;
				cost = pre.cost + Coordinate.GetDistance(con.Coordinate, end.Coordinate);
			}
		}
	}
}
