using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {
    class Maintenance : RoadMaintenanceTask {
        private bool RoadDamage;

        public Maintenance(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority, bool roadDamage) 
        : base(taskName, taskDecription, streetConnectors, priority) {
            this.RoadDamage = roadDamage;
        }

        public bool getRoadDamage() {
            return RoadDamage;
        }
    }
}