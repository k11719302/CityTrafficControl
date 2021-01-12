using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS1
{
    class TrafficDetection
    {
        private static TrafficDetection instance = null; //using Singleton, because SS1 only needs one traffic detector

        private TrafficDetection() { }

        public static TrafficDetection GetInstance //creates the first instance or always returns the singleton instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrafficDetection();
                }
                return instance;
            }
        }
    }
}
