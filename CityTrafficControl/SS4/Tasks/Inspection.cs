using System;

namespace CityTrafficControl.SS4.Tasks {
    class Inspection : RoadMaintenanceTask {
        public Inspection(string taskName, string taskDecription, int priority) 
        : base(taskName, taskDecription, priority) {
        }
    }
}