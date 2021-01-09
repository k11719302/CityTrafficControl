using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficControlAndDetection
{
    class CrossroadPlan
    {
        private int crossroadId;
        public int CrossroadId { get { return crossroadId; } }

        private List<TrafficLightPlan> plans;   //contains all the traffic light cycles of the lights at this crossroad
        public List<TrafficLightPlan> Plans { get { return plans; } }

        public CrossroadPlan (int crossroadId, List<TrafficLightPlan> plans)
        { 
            this.crossroadId = crossroadId;
            this. plans = plans;
        }

        //public CrossroadPlan(int crossroadId)
        //{
        //    this.crossroadId = crossroadId;
        //    plans = new List<TrafficLightPlan>();
        //}




    }
}
