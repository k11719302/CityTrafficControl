using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    class RoadInstruction
    {
        //A roadInstruction will be send to SS1 if either the speedlimit or a roadstatus needs to be changed
        private int id;
        private int speedlimit;
        private RoadStatus status;
       

        public RoadInstruction(int id, int speedlimit, RoadStatus status)
        {
            this.id = id;
            this.speedlimit = speedlimit;
            this.status = status;
        }

        public int Id { get => id; }
        public int Speedlimit { get => speedlimit; }
        public RoadStatus Status { get => status; }
       

    }
}
