using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    class Intersection
    {
        //Plans for all trafficlights are grouped in intersections
        private int id;
        private List<TrafficlightPlan> trafficlightPlans;

        public Intersection(int id, List<TrafficlightPlan> trafficlightPlans)
        {
            this.id = id;
            this.trafficlightPlans = trafficlightPlans;
        }

        public int Id { get { return id; } }
        public List<TrafficlightPlan> TrafficlightPlans { get { return trafficlightPlans; } }
    }
}
