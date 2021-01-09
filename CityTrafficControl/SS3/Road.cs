using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    class Road
    {
        private int id;
        private int speedlimit;
        private double length;
        private double time;
        private RoadStatus status;
        private RoadRestrictionTypes restriction;
        private List<Road> conected;

        public Road(int id, int speedlimit, double length, RoadStatus status, RoadRestrictionTypes restriction, List<Road> conected)
        {
            this.id = id;
            this.speedlimit = speedlimit;
            this.length = length;
            time = CalcTime();
            this.status = status;
            this.restriction = restriction;
            this.conected = conected;
        }

        public int Id { get => id; }
        public int Speedlimit { get => GetSpeedlimit(); }
        public double Length { get => length; }
        public double Time { get => time; }
        public RoadStatus Status { get => GetStatus(); }
        public RoadRestrictionTypes Restriction { get => restriction; }
        public List<Road> Conected { get => conected; }

        //Updates data, when requested
        public RoadStatus GetStatus() 
        {
            Roadinformation r = new Roadinformation(id);
            return r.Status;
        }
        public int GetSpeedlimit()
        {
            Roadinformation r = new Roadinformation(id);
            return r.Speedlimit;
        }
       
        public double CalcTime()
        {
            return length / Speedlimit;
        }
    }

    enum RoadStatus
    { 
        FREE,
        BLOCKED
    }

    enum RoadRestrictionTypes
    {
        HIGHWAY,
        EXPRESSWAY,
        BRIDGE,
        TUNNEL
    }
}
