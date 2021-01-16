using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS1
{
    //SS1 receives commands for the roads from the DataLinker
    class RoadCommand
    {
        private int roadId;
        public int RoadId { get { return roadId; } }

        private bool state;
        public bool State { get { return state; } }

        private double speedLimit;
        public double SpeedLimit { get { return speedLimit; } }

        public RoadCommand (int id, bool state, double speedLimit)
        {
            this.roadId = id;
            this.state = state;
            this.speedLimit = speedLimit;
        }
    }
}
