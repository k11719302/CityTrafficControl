using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    abstract class Path
    {
        private int id;
        private double time;
        private double length;
        private Road start;
        private Road end;
        private List<Road> roads;

        public Path(int id, Road start, Road end)
        {
            this.id = id;
            this.start = start;
            this.end = end;
            time = CalcTime();
            length = CalcLength();
            roads = CalcPath();
        }

        public int Id { get => id; }
        public double Time { get => time; }
        public double Length { get => length; }
        public Road Start { get => start; }
        public Road End { get => end; }
        public List<Road> Roads { get => roads; }

        public abstract List<Road> CalcPath();

        public double CalcTime()
        {
            double t = 0;
            foreach (Road r in roads)
            {
                t = t + r.Time;
            }
            return t;
        }

        public double CalcLength()
        {
            double l = 0;
            foreach (Road r in roads)
            {
                l = l + r.Length;
            }
            return l;
        }

    }

    class ShortestPath : Path
    {
        public ShortestPath(int id, Road start, Road end) : base(id, start, end) { }
        public override List<Road> CalcPath()
        {
            throw new NotImplementedException();
        }
    }

    class FastestPath : Path
    {
        public FastestPath(int id, Road start, Road end) : base(id, start, end) { }
        public override List<Road> CalcPath()
        {
            throw new NotImplementedException();
        }
    }
}
