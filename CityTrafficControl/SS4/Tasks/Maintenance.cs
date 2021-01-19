using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {
    class Maintenance : RoadMaintenanceTask {
        private bool RoadDamage;


        /// <summary>
        /// Creates a maintenance object.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        /// <param name="roadDamage">Shows whether the road is damaged or not.</param>
        public Maintenance(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority, bool roadDamage) 
        : base(taskName, taskDecription, streetConnectors, priority) {
            this.RoadDamage = roadDamage;
        }

        /// <summary>
        /// Specifies whether there road damage or not.
        /// </summary>
        /// <returns>The flag which decides whether there is damage.</returns>
        public bool getRoadDamage() {
            return RoadDamage;
        }
    }
}