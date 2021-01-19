using CityTrafficControl.SS4.StaffManagement;
using CityTrafficControl.SS4.StaffManagement.EquipmentManagement;
using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {

    /// <summary>
    /// Class for a basic RoadMaintenanceTask object.
    /// </summary>
    public abstract class RoadMaintenanceTask {
        private List<Team> AssignedTeams;
        private List<Equipment> AssignedEquipment;
        private string TaskName;
        private string TaskDecription;
        private List<StreetConnector> StreetConnectors;
        private int Priority; // Ranges from 1 to 5

        /// <summary>
        /// Creates a basic RoadMaintenanceTask object.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        protected RoadMaintenanceTask(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority) {
            this.AssignedTeams = new List<Team>();
            this.AssignedEquipment = new List<Equipment>();
            this.TaskName = taskName;
            this.TaskDecription = taskDecription;
            this.StreetConnectors = streetConnectors;
            if (1 <= priority && priority <= 5) {
                this.Priority = priority;
            } else {
                this.Priority = 1;
            }
        }

        /// <summary>
        /// Get a list of streetconnectors.
        /// </summary>
        /// <returns>A list of streetconnectors.</returns>
        public List<StreetConnector> GetStreetConnectors(){
            return StreetConnectors;
        }

        /// <summary>
        /// Method to assign a team to a task.
        /// </summary>
        /// <param name="team">The team which is assigned.</param>
        public void AssignTeam(Team team) {
            AssignedTeams.Add(team);
        }


        /// <summary>
        /// Method to assign equipment to a task.
        /// </summary>
        /// <param name="equipment">The equipment which is assigned.</param>
        public void AssignEquipment(Equipment equipment) {
            AssignedEquipment.Add(equipment);
        }


        /// <summary>
        /// Method which reassigns the priority of a task.
        /// </summary>
        /// <param name="priority">The given priorty.</param>
        public void ReassignPriority(int priority) {
            if (1 <= priority && priority <= 5) {
                this.Priority = priority;
            } else {
                this.Priority = 1;
            }
        }
    }
}