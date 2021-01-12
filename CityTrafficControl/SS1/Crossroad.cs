using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS1
{
    public class Crossroad
    {
        private int id;
        public int Id { get { return id; } }

        private List<TrafficLight> lights; //only find, add, remove should be possible to carry out outside of the class

        private List<RoadSegment> roadSegments; //only find, add, remove should be possible to carry out outside of the class

        public Crossroad (int id)
        {
            this.id = id;
            lights = new List<TrafficLight>();
            roadSegments = new List<RoadSegment>();
        }

        public TrafficLight findLight (int id)
        {
            return lights.Find(x => x.Id == id);
        }
        
        public bool addLight (TrafficLight light)
        {
            if (light.CrossroadId == this.id)
            {
                lights.Add(light);
                return true;
            }
            return false;
        }

        public bool removeLight (TrafficLight light)
        {
            return lights.Remove(light);
        }

        public RoadSegment findRoadSegment (int id)
        {
            return roadSegments.Find(x => x.Id == id);
        }

        public bool addRoadSegment (RoadSegment road)
        {
            if(road.CrossroadId == this.id)
            {
                roadSegments.Add(road);
                return true;
            }
            return false;
        }

        public bool removeRoadSegment (RoadSegment road)
        {
            return roadSegments.Remove(road);
        }

        public void PrintCrossroad()
        {
            Console.WriteLine("crossroad " + id + ": ");
            Console.WriteLine("lights: ");
            foreach (TrafficLight l in lights)
            {
                
                if (l != null)
                {
                    l.PrintLight();
                }
                
            }
            Console.WriteLine("roads: ");
            foreach (RoadSegment r in roadSegments)
            {
                if (r != null)
                {
                    r.PrintRoad();
                }
            }
        }

    }
}
