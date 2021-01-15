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
        private static int nRoads = 0;
        private static List<Road> roads = new List<Road>();

        public Road(int id, int speedlimit, double length, RoadStatus status, RoadRestrictionTypes restriction)
        {
            this.id = id;
            this.speedlimit = speedlimit;
            this.length = length;
            time = CalcTime();
            this.status = status;
            this.restriction = restriction;
            this.conected = conected;
            nRoads += 1;
            roads.Add(this);
        }

        public int Id { get { return id; } }
        public int Speedlimit { get { return speedlimit; } }
        public double Length { get { return length; } }
        public double Time { get { return time; } }
        public RoadStatus Status { get { return GetStatus(); } }
        public RoadRestrictionTypes Restriction { get { return restriction; } }
        public List<Road> Conected { get { return conected; } }
        public static int NRoads { get { return nRoads; } }
        public static List<Road> Roads { get { return roads; } }

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
        TUNNEL,
        NONE
    }
}
