using System;

namespace CityTrafficControl.SS4.Tasks {
    class Maintenance : RoadMaintenanceTask {
        private bool RoadDamage;

        public Maintenance(string taskName, string taskDecription, int priority, bool roadDamage) 
        : base(taskName, taskDecription, priority) {
            this.RoadDamage = roadDamage;
        }

        public bool getRoadDamage() {
            return RoadDamage;
        }
    }
}