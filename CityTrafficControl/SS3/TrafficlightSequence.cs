using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    class TrafficlightSequence
    {
        private double[] durations;
        private TrafficlightStatus[] status;

        public TrafficlightSequence(double[] durations, TrafficlightStatus[] status)
        {
            this.durations = durations;
            this.status = status;
        }

        public double[] Durations { get { return durations; } }
        public TrafficlightStatus[] Status { get { return status; } }
    }

    enum TrafficlightStatus
    {
        RED,
        GREEN
    }
}
