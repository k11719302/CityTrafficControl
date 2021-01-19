using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {
    class NaturalDisaster : RoadMaintenanceTask {
        private string DisasterType;
        private bool RoadDamage;
        private int Blockages;

        /// <summary>
        /// Creates a natural disaster object.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        /// <param name="disasterType">Specifies the type of disaster.</param>
        /// <param name="roadDamage">Shows whether the road is damaged or not.</param>
        /// <param name="blockages">Specifies the number of blockages.</param>
        public NaturalDisaster(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority, string disasterType, bool roadDamage, int blockages) 
        : base(taskName, taskDecription, streetConnectors, priority) {
            this.DisasterType = disasterType;
            this.RoadDamage = roadDamage;
            this.Blockages = blockages;
        }


        /// <summary>
        /// Get the type of the disaster.
        /// </summary>
        /// <returns>The type of the disaster.</returns>
        public string getDisasterType() {
            return DisasterType;
        }


        /// <summary>
        /// Specifies whether there road damage or not.
        /// </summary>
        /// <returns>The flag which decides whether there is damage.</returns>
        public bool getRoadDamage() {
            return RoadDamage;
        }


        /// <summary>
        /// Get the amount of blockages.
        /// </summary>
        /// <returns>The amount of blockages.</returns>
        public int getBlockages() {
            return Blockages;
        }
    }
}