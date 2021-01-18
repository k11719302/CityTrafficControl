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
			List<Node> pq = new List<Node>();
			List<StreetConnector> visited = new List<StreetConnector>();
			Node cur = new Node(start, end);
			
			pq.Add(cur);
			while(pq.Count > 0)
            {
				double min = pq.Min(x => x.cost);
				cur = pq.First(x => x.cost == min);
				pq.RemoveAt(0);
				if (cur.con == end)
				{
					CreatePath(cur.pre);
					return true;
				}
				visited.Add(cur.con);
				foreach (StreetConnector sc in cur.con.FindNeighbours())
                {
                    if (!visited.Contains(sc))
                    {
						Node n = new Node(cur, sc, end);
						pq.Add(n);	
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
				cost = pre.cost + Coordinate.GetDistance(pre.con.Coordinate, con.Coordinate);
			}
		}
	}
}
