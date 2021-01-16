using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS1
{
    public class Crossroad
    {
        private int id;
        public int Id { get { return id; } }

        private List<TrafficLight> lights; //only find, add, remove should be possible to carry out outside of the class

        public Crossroad (int id)
        {
            this.id = id;
            lights = new List<TrafficLight>();
        }

        public TrafficLight findLight (int id)
        {
            return lights.Find(x => x.Id == id);
        }
        
        public bool addLight (TrafficLight light)
        {
            if (light.CrossroadId == this.id)
            {
                lights.Add(light);
                return true;
            }
            return false;
        }

        public bool removeLight (TrafficLight light)
        {
            return lights.Remove(light);
        }

        public void PrintCrossroad()
        {
            Console.WriteLine("crossroad " + id + ": ");
            Console.WriteLine("lights: ");
            foreach (TrafficLight l in lights)
            {
                
                if (l != null)
                {
                    l.PrintLight();
                }
                
            }
        }

    }
}
