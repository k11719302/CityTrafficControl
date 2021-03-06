using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {

    class Accident : RoadMaintenanceTask {
        private int NumberOfVehicles;
        private bool RoadDamage;

        /// <summary>
        /// Creates a new accident object.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        /// <param name="numberOfVehicles">Shows the amount of vehicles.</param>
        /// <param name="roadDamage">Shows whether the road is damaged or not.</param>
        public Accident(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority, int numberOfVehicles, bool roadDamage) 
        : base(taskName, taskDecription, streetConnectors, priority) {
            this.NumberOfVehicles = numberOfVehicles;
            this.RoadDamage = roadDamage;
        }


        /// <summary>
        /// Get the number of involved vehicles.
        /// </summary>
        /// <returns>The number of vehicles.</returns>
        public int getNumberOfVehicles() {
            return NumberOfVehicles;
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