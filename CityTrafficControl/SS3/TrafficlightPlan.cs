using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    class TrafficlightPlan
    {
        //Trafficplan give a sequenz of instruktions for each trafficlight
        private int trafficlightId;
        private TrafficlightSequence sequence;

        public TrafficlightPlan(int trafficlightId, TrafficlightSequence sequence)
        {
            this.trafficlightId = trafficlightId;
            this.sequence = sequence;
        }

        public int TrafficlightId { get { return trafficlightId; } }
        public TrafficlightSequence Sequenz { get { return sequence; } }
    }
}
