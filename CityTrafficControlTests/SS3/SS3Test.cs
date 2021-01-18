using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.Master.DataStructures;
using CityTrafficControl.SS3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.SS1;

namespace CityTrafficControlTests.SS3
{
    [TestClass()]
    public class SS3Test
    {
        [TestMethod()]
        public void TestGetConnectingStreetSegments()
        {
            List<StreetConnector> sc1 = new List<StreetConnector>();
            StreetConnector c1 = new StreetConnector(0, 0);
            StreetConnector c2 = new StreetConnector(0, 50);
            StreetConnector c3 = new StreetConnector(0, 120);
            sc1.Add(c1);
            sc1.Add(c2);
            sc1.Add(c3);

            List<StreetSegment> ss1 = new List<StreetSegment>();
            StreetSegment s1 = new StreetSegment(c1, c2);
            StreetSegment s2 = new StreetSegment(c2, c3);
            ss1.Add(s1);
            ss1.Add(s2);

            List<StreetSegment> sTest1 = ControlSystem.GetConnectingStreetSegments(sc1);

            Assert.AreEqual(2, sTest1.Count());
            Assert.AreEqual(true, sTest1.Contains(s1));
            Assert.AreEqual(true, sTest1.Contains(s2));
        }

        [TestMethod()]
        public void TestGetConnectingStreetSegmentWithStreetHub()
        {
            List<StreetConnector> sc1 = new List<StreetConnector>();
            StreetConnector c1 = new StreetConnector(0, 0);
            StreetConnector c2 = new StreetConnector(0, 50);
            StreetConnector c3 = new StreetConnector(0, 120);
            StreetConnector ch1 = new StreetConnector(0, 200);
            StreetConnector ch2 = new StreetConnector(0, 210);
            StreetConnector ch3 = new StreetConnector(5, 205);
            StreetConnector c4 = new StreetConnector(0, 300);
            StreetConnector c5 = new StreetConnector(50, 205);
            sc1.Add(c1);
            sc1.Add(c2);
            sc1.Add(c3);
            sc1.Add(ch1);
            sc1.Add(ch2);
            sc1.Add(ch3);
            sc1.Add(c4);
            sc1.Add(c5);

            List<StreetConnector> h = new List<StreetConnector>();
            h.Add(ch1);
            h.Add(ch2);
            h.Add(ch3);

            List<StreetSegment> ss1 = new List<StreetSegment>();
            StreetSegment s1 = new StreetSegment(c1, c2);
            StreetSegment s2 = new StreetSegment(c2, c3);
            StreetSegment s3 = new StreetSegment(c3, ch1);
            StreetSegment s4 = new StreetSegment(ch2, c4);
            StreetSegment s5 = new StreetSegment(ch3, c5);
            ss1.Add(s1);
            ss1.Add(s2);
            ss1.Add(s3);
            ss1.Add(s4);
            ss1.Add(s5);

            List<StreetSegment> sTest1 = ControlSystem.GetConnectingStreetSegments(sc1);
            Assert.AreEqual(5, sTest1.Count());
            Assert.AreEqual(true, sTest1.Contains(s1));
            Assert.AreEqual(true, sTest1.Contains(s2));
            Assert.AreEqual(true, sTest1.Contains(s3));
            Assert.AreEqual(true, sTest1.Contains(s4));
            Assert.AreEqual(true, sTest1.Contains(s5));
        }

        [TestMethod()]
        public void TestShortestPath()
        {
            List<StreetConnector> sc = new List<StreetConnector>();
            StreetConnector c1 = new StreetConnector(0, 0);
            StreetConnector c2 = new StreetConnector(0, 50);
            StreetConnector c3 = new StreetConnector(0, 120);
            StreetConnector c4 = new StreetConnector(20, 0);
            StreetConnector c5 = new StreetConnector(20, 40);
            StreetConnector c6 = new StreetConnector(20, 100);
            sc.Add(c1);
            sc.Add(c2);
            sc.Add(c3);
            sc.Add(c4);
            sc.Add(c5);
            sc.Add(c6);

            List<StreetSegment> ss = new List<StreetSegment>();
            StreetSegment s1 = new StreetSegment(c1, c2);
            StreetSegment s2 = new StreetSegment(c2, c3);
            StreetSegment s3 = new StreetSegment(c1, c4);
            StreetSegment s4 = new StreetSegment(c4, c5);
            StreetSegment s5 = new StreetSegment(c5, c6);
            StreetSegment s6 = new StreetSegment(c6, c3);
            ss.Add(s1);
            ss.Add(s2);
            ss.Add(s3);
            ss.Add(s4);
            ss.Add(s5);
            ss.Add(s6);

            BaseRoute b = new ShortestBaseRoute(c1, c6);
            Assert.AreEqual(2, b.Waypoints.Count);
            Assert.AreEqual(true, b.Waypoints[0] == c4);
            Assert.AreEqual(true, b.Waypoints[1] == c5);
        }

       

        [TestMethod()]
        public void TestAddIntersectionPlan()
        {
            List<TrafficLightPlan> l = new List<TrafficLightPlan>();
            TrafficLightPlan p1 = new TrafficLightPlan(1, 30, 40);
            TrafficLightPlan p2 = new TrafficLightPlan(1, 40, 50);

            l.Add(p1);
            l.Add(p2);

            Assert.AreEqual(1, l.Count);
            Assert.AreEqual(true, l.Contains(p2));

        }

    }
}
