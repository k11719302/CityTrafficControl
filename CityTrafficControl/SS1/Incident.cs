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

        public Incident(IncidentType type, List<StreetConnector> connectors)
        {
            this.type = type;
            this.connectors = connectors;
        }
    }

    public enum IncidentType{
        ACCIDENT,
        NATDISASTER
    }
}
