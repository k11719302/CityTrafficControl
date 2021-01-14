using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS1
{
    public class Incident
    {
        private IncidentType type; //natural disaster or accident
        public IncidentType Type { get { return type; } }

        private StreetConnector connector; //involved street connector
        public StreetConnector Connector { get { return connector; } }

        private string descprition;
        public string Description { get { return descprition; } }

        private int priority; //number between 1 and 5
        public int Priority { get { return priority; } }

        //nr of involved cars in case of an accident
        //or nr of objects blocking the road in case of a nat. disaster
        private int involvedObjects;
        public int InvolvedObjects { get { return involvedObjects; } }

        private bool roadDamage;
        public bool RoadDamage { get { return roadDamage; } }

        public Incident(IncidentType type, StreetConnector connector, string descr, int priority, int nrOfObjects, bool damage)
        {
            this.type = type;
            this.connector = connector;
            descprition = descr;
            this.priority = priority;
            involvedObjects = nrOfObjects;
            roadDamage = damage;
        }
    }

    public enum IncidentType{
        ACCIDENT,
        NATDISASTER
    }
}
