using System;

namespace CityTrafficControl.SS4.Tasks {
    class Accident : RoadMaintenanceTask {
        private int NumberOfVehicles;
        private bool RoadDamage;

        public Accident(string taskName, string taskDecription, int priority, int numberOfVehicles, bool roadDamage) 
        : base(taskName, taskDecription, priority) {
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