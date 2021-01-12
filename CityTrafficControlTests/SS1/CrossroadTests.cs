using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityTrafficControl.SS1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS1.Tests
{
    [TestClass()]
    public class CrossroadTests
    {
        Crossroad cr = new Crossroad(1);

        [TestMethod()]
        public void addLightTest()
        {
            //traffic light with correct crossroad id should be added
            TrafficLight light1 = new TrafficLight(1, null, LightStates.GREEN, 1);
            Assert.AreEqual(true, cr.addLight(light1));
            Assert.AreEqual(light1, cr.findLight(1));
            
            //traffic light with the wrong crossroad id should not be added
            TrafficLight light2 = new TrafficLight(1, null, LightStates.GREEN, 3);
            Assert.AreEqual(false, cr.addLight(light2));
            Assert.AreEqual(null, cr.findLight(3));
        }

        [TestMethod()]
        public void removeLightTest()
        {
            //existing traffic light should be removed
            TrafficLight light1 = new TrafficLight(1, null, LightStates.GREEN, 1);
            cr.addLight(light1);
            Assert.AreEqual(true, cr.removeLight(light1));
            Assert.AreEqual(null, cr.findLight(1));

            //light which is not in the list
            TrafficLight light2 = new TrafficLight(1, null, LightStates.GREEN, 3);
            Assert.AreEqual(false, cr.removeLight(light2));
            Assert.AreEqual(null, cr.findLight(3));
        }

        [TestMethod()]
        public void addRoadSegmentTest()
        {
            //road with correct crossroad id should be added
            RoadSegment road1 = new RoadSegment(RoadTypes.HIGHWAY, 1, null,null,RoadStates.BLOCKED,2,60,1);
            Assert.AreEqual(true, cr.addRoadSegment(road1));
            Assert.AreEqual(road1, cr.findRoadSegment(1));

            //traffic light with the wrong crossroad id should not be added
            RoadSegment road2 = new RoadSegment(RoadTypes.HIGHWAY, 2, null, null, RoadStates.BLOCKED, 2, 60, 4);
            Assert.AreEqual(false, cr.addRoadSegment(road2));
            Assert.AreEqual(null, cr.findRoadSegment(3));
        }

        [TestMethod()]
        public void removeRoadSegmentTest()
        {
            //existing road should be removed
            RoadSegment road1 = new RoadSegment(RoadTypes.HIGHWAY, 1, null, null, RoadStates.BLOCKED, 2, 60, 1);
            cr.addRoadSegment(road1);
            Assert.AreEqual(true, cr.removeRoadSegment(road1));
            Assert.AreEqual(null, cr.findRoadSegment(1));

            //road which is not in the list
            RoadSegment road2 = new RoadSegment(RoadTypes.HIGHWAY, 5, null, null, RoadStates.BLOCKED, 2, 60, 5);
            Assert.AreEqual(false, cr.removeRoadSegment(road2));
            Assert.AreEqual(null, cr.findLight(5));
        }
    }
}