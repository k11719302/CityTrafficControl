using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    public class RoadInstruction
    {
        //A roadInstruction will be send to SS1 if either the speedlimit or a roadstatus needs to be changed
        private int id;
        private double speedlimit;
        private bool usable;
       

        public RoadInstruction(int id, double speedlimit, bool usable)
        {
            this.id = id;
            this.speedlimit = speedlimit;
            this.usable = usable;
        }

        public int Id { get { return id; } }
        public double Speedlimit { get { return speedlimit; } }
        public bool Usable { get { return usable; } }
       

    }
}
