using CityTrafficControl;
using CityTrafficControl.Master;
using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControlTests.SS2.DataStructures {
	[TestClass]
	public class SpecialRouteTests {
		// NOTE: The tests assume the StreetMap (City) as defined in the Excel file!

		[TestInitialize]
		public void InitTests() {
			StreetMapManager.Init();
		}

		[TestMethod]
		public void Test_SameStreetConnector() {
			SpecialRoute route;
			StreetConnector connector;
			StreetConnector start, end;
			List<StreetConnector> waypoints = new List<StreetConnector>();

			for (int i = 0; i < StreetMapManager.Data.StreetConnectorsCount; i++) {
				connector = start = end = StreetMapManager.Data.StreetConnectors(i);

				route = new SpecialRoute(connector, connector);

				Assert.AreEqual(start, route.Start, "Start StreetConnector doesn't match");
				Assert.AreEqual(end, route.End, "End StreetConnector doesn't match");
				Assert.AreEqual(waypoints.Count, route.Waypoints.Count, "There shouldn't be any waypoints");
			}
		}

		[TestMethod]
		public void Test_SingleStreetSegmentDistance() {
			SpecialRoute route;
			StreetConnector connector1, connector2;
			StreetConnector start, end;
			List<StreetConnector> waypoints = new List<StreetConnector>();

			connector1 = start = StreetMapManager.Data.StreetConnectors(0);
			connector2 = end = StreetMapManager.Data.StreetConnectors(1);

			route = new SpecialRoute(connector1, connector2);

			Assert.AreEqual(start, route.Start, "Start StreetConnector doesn't match");
			Assert.AreEqual(end, route.End, "End StreetConnector doesn't match");
			Assert.AreEqual(waypoints.Count, route.Waypoints.Count, "There shouldn't be any waypoints");
		}

		[TestMethod]
		public void Test_SingleStreetHubDistance() {
			SpecialRoute route;
			StreetConnector connector1, connector2;
			StreetConnector start, end;
			List<StreetConnector> waypoints = new List<StreetConnector>();

			connector1 = start = StreetMapManager.Data.StreetConnectors(0);
			connector2 = end = StreetMapManager.Data.StreetConnectors(5);

			route = new SpecialRoute(connector1, connector2);

			Assert.AreEqual(start, route.Start, "Start StreetConnector doesn't match");
			Assert.AreEqual(end, route.End, "End StreetConnector doesn't match");
			Assert.AreEqual(waypoints.Count, route.Waypoints.Count, "There shouldn't be any waypoints");
		}

		[TestMethod]
		public void Test_StreetSegmentSequence() {
			SpecialRoute route;
			StreetConnector connector1, connector2;
			StreetConnector start, end;
			List<StreetConnector> waypoints = new List<StreetConnector>();

			connector1 = start = StreetMapManager.Data.StreetConnectors(0);
			connector2 = end = StreetMapManager.Data.StreetConnectors(4);

			waypoints.Add(StreetMapManager.Data.StreetConnectors(1));
			waypoints.Add(StreetMapManager.Data.StreetConnectors(2));
			waypoints.Add(StreetMapManager.Data.StreetConnectors(3));

			route = new SpecialRoute(connector1, connector2);

			Assert.AreEqual(start, route.Start, "Start StreetConnector doesn't match");
			Assert.AreEqual(end, route.End, "End StreetConnector doesn't match");
			Assert.AreEqual(waypoints.Count, route.Waypoints.Count, "There shouldn't be any waypoints");
			for (int i = 0; i < waypoints.Count; i++) {
				Assert.AreEqual(waypoints.ElementAt(i), route.Waypoints.ElementAt(i), string.Format("Waypoint {0} doesn't match", i));
			}
		}
	}
}
