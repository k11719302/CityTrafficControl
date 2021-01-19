using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {

    class Inspection : RoadMaintenanceTask {
        public Inspection(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority) 
        : base(taskName, taskDecription, streetConnectors, priority) {
        }
    }
}