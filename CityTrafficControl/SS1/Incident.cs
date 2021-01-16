using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS1
{
    class Incident
    {
        private IncidentType type; //natural disaster or accident
        public IncidentType Type { get { return type; } }

        private List<StreetConnector> connectors; //involved street connectors
        public List<StreetConnector> Connectors { get { return connectors; } }

        private string descprition;
        public string Description { get { return descprition; } }

        private double priority;
        public double Priority { get { return priority; } }

        //nr of involved cars in case of an accident
        //or nr of objects blocking the road in case of a nat. disaster
        private int involvedObjects;
        public int InvolvedObjects { get { return involvedObjects; } }

        private bool roadDamage;
        public bool RoadDamage { get { return roadDamage; } }

        public Incident(IncidentType type, List<StreetConnector> connectors, string descr, double priority, int nrOfObjects, bool damage)
        {
            this.type = type;
            this.connectors = connectors;
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
