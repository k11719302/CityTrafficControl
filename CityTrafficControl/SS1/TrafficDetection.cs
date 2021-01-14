using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;


namespace CityTrafficControl.SS1
{
    public class TrafficDetection
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

        //gets called by a participant for simulation
        //creates the incident objects and informs the TrafficControl
        public static void IncidentHappened(IncidentType type, StreetConnector connector, int involvedObjects, bool roadDamage)
        {
            Incident incident = new Incident(type, connector, " ", CalculateIncidentPriority(type, involvedObjects, roadDamage), involvedObjects, roadDamage);
            TrafficControl.IncidentDetected(incident);
        }

        //calculates a number between 1 to 5, which later informs SS4 about the importance 
        private static int CalculateIncidentPriority(IncidentType type, int involvedObjects, bool roadDamage)
        {
            //TODO calculation
            return 1;
        }

    }
}
