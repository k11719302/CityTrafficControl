using CityTrafficControl.SS4.StaffManagement;
using CityTrafficControl.SS4.StaffManagement.EquipmentManagement;
using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {
    abstract class RoadMaintenanceTask {
        private List<Team> AssignedTeams;
        private List<Equipment> AssignedEquipment;
        private string TaskName;
        private string TaskDecription;
        private List<StreetConnector> StreetConnectors;
        private int Priority; // Ranges from 1 to 5

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

        public List<StreetConnector> GetStreetConnectors(){
            return StreetConnectors;
        }

        public void AssignTeam(Team team) {
            AssignedTeams.Add(team);
        }

        public void AssignEquipment(Equipment equipment) {
            AssignedEquipment.Add(equipment);
        }

        public void ReassignPriority(int priority) {
            if (1 <= priority && priority <= 5) {
                this.Priority = priority;
            } else {
                this.Priority = 1;
            }
        }
    }
}