using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;


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

        /// <summary>
        /// This method gets called by the system when a new incident (accident or natural disaster) has been simulated.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connector"></param>
        /// <param name="involvedObjects"></param>
        /// <param name="roadDamage"></param>
        public static void IncidentHappened(IncidentType type, List<StreetConnector> connector, int involvedObjects, bool roadDamage)
        {
            Incident incident = new Incident(type, connector, " ", -1, involvedObjects, roadDamage);
            TrafficControl.IncidentDetected(incident);
        }

    }
}
