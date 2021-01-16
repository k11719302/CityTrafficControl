using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {
    class Accident : RoadMaintenanceTask {
        private int NumberOfVehicles;
        private bool RoadDamage;

        public Accident(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority, int numberOfVehicles, bool roadDamage) 
        : base(taskName, taskDecription, streetConnectors, priority) {
            this.NumberOfVehicles = numberOfVehicles;
            this.RoadDamage = roadDamage;
        }

        public int getNumberOfVehicles() {
            return NumberOfVehicles;
        }

        public bool getRoadDamage() {
            return RoadDamage;
        }
    }
}