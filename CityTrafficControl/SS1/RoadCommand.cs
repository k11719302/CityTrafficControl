using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficControlAndDetection
{
    //SS1 receives commands for the roads from the DataLinker
    class RoadCommand
    {
        private int roadId;
        public int RoadId { get { return roadId; } }

        private RoadStates state;
        public RoadStates State { get { return state; } }

        private bool changeState = true;   //boolean to show, whether the state should be changed or not
        public bool ChangeState { get { return changeState; } }

        private int speedLimit = -1;
        public int SpeedLimit { get { return speedLimit; } }

        //if only the state should be changed
        public RoadCommand (int id, RoadStates state) 
        {
            this.roadId = id;
            this.state = state;
        }

        //if only the speedLimit should be changed --> set changeState to false and choose speedLimit 
        public RoadCommand (int id, bool changeState, int speedLimit)
        {
            this.roadId = id;
            this.changeState = changeState;
            this.speedLimit = speedLimit;
        }

        public RoadCommand (int id, RoadStates state, int speedLimit)
        {
            this.roadId = id;
            this.state = state;
            this.speedLimit = speedLimit;
        }
    }
}
