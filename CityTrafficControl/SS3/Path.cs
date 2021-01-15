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

        public int Id { get { return id; } }
        public double Time { get { return time; } }
        public double Length { get { return length; } }
        public Road Start { get { return start; } }
        public Road End { get { return end; } }
        public List<Road> Roads { get { return roads; } }

        public abstract List<Road> CalcPath();

        public double CalcTime()
        {
            double t = 0;
            if (roads != null)
            {
                foreach (Road r in roads)
                {
                    t = t + r.Time;
                }
            }
            return t;
        }

        public double CalcLength()
        {
            double l = 0;
            if (roads != null)
            {
                foreach (Road r in roads)
                {
                    l = l + r.Length;
                }
            }
            return l;
        }

    }

    class ShortestPath : Path
    {
        public ShortestPath(int id, Road start, Road end) : base(id, start, end) { }
        public override List<Road> CalcPath()
        {
            List<Road> path = new List<Road>();
            Road[] r = new Road[Road.NRoads];
            double[] v = new double[Road.NRoads];
            SortedList<double, Road> pq = new SortedList<double, Road>(new PQ<double>());
            for (int i = 0; i < Road.NRoads; i++)
            {
                if (Start == Road.Roads[i])
                {
                    v[i] = 0;
                }
                else
                {
                    v[i] = int.MaxValue;
                }
                r[i] = Road.Roads[i];
                pq.Add(v[i], Road.Roads[i]);
            }
            while (pq.Count != 0)
            {
                double curK = pq.Keys[0];
                Road curE = pq.Values[0];
                pq.RemoveAt(0);
                foreach (Road x in curE.Conected)
                {
                    if (pq.ContainsValue(x) == true)
                    {
                        if ((double)(curK + curE.Length) < (double)(v[Array.IndexOf(r, x)]))
                        {
                            int i = Array.IndexOf(r, x);
                            v[i] = curK + curE.Time;
                            pq.RemoveAt(pq.IndexOfValue(x));
                            pq.Add(v[i], x);
                        }
                    }
                }
            }

            int j = Array.IndexOf(r, End);
            path.Add(End);
            while (r[j] != Start)
            {
                double min = double.MaxValue;
                Road minRoad = r[j];
                foreach (Road x in r[j].Conected)
                {
                    if (v[Array.IndexOf(r, x)] < min)
                    {
                        min = v[Array.IndexOf(r, x)];
                        minRoad = x;
                    }
                }
                path.Add(minRoad);
                j = Array.IndexOf(r, minRoad);
            }
            path.Reverse();
            return path;
        }
    }

    class FastestPath : Path
    {
        public FastestPath(int id, Road start, Road end) : base(id, start, end) { }
        public override List<Road> CalcPath()
        {
            List<Road> path = new List<Road>();
            Road[] r = new Road[Road.NRoads];
            double[] v = new double[Road.NRoads];
            SortedList<double, Road> pq = new SortedList<double, Road>(new PQ<double>());
            for (int i = 0; i < Road.NRoads; i++)
            {
                if (Start == Road.Roads[i])
                {
                    v[i] = 0;
                }
                else
                {
                    v[i] = int.MaxValue;
                }
                r[i] = Road.Roads[i];
                pq.Add(v[i], Road.Roads[i]);
            }
            while (pq.Count != 0)
            {
                double curK = pq.Keys[0];
                Road curE = pq.Values[0];
                pq.RemoveAt(0);
                foreach (Road x in curE.Conected)
                {
                    if (pq.ContainsValue(x) == true)
                    {
                        if ((double)(curK + curE.Time) < (double)(v[Array.IndexOf(r, x)]))
                        {
                            int i = Array.IndexOf(r, x);
                            v[i] = curK + curE.Time;
                            pq.RemoveAt(pq.IndexOfValue(x));
                            pq.Add(v[i], x);
                        }
                    }
                }
            }

            int j = Array.IndexOf(r, End);
            path.Add(End);
            while (r[j] != Start)
            {
                double min = double.MaxValue;
                Road minRoad = r[j];
                foreach (Road x in r[j].Conected)
                {
                    if (v[Array.IndexOf(r, x)] < min)
                    {
                        min = v[Array.IndexOf(r, x)];
                        minRoad = x;
                    }
                }
                path.Add(minRoad);
                j = Array.IndexOf(r, minRoad);
            }
            path.Reverse();
            return path;
        }

    }
}
