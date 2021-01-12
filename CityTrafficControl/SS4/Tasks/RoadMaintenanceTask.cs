using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4.Tasks {
    abstract class RoadMaintenanceTask {
        private List<Team> AssignedTeams;
        private List<Equipment> AssignedEquipment;
        private string TaskName;
        private string TaskDecription;
        private int Priority; // Ranges from 1 to 5

        protected RoadMaintenanceTask(string taskName, string taskDecription, int priority) {
            this.AssignedTeams = new List<Team>();
            this.AssignedEquipment = new List<Equipment>();
            this.TaskName = taskName;
            this.TaskDecription = taskDecription;
            if (1 <= priority && priority <= 5) {
                this.Priority = priority;
            } else {
                this.Priority = 1;
            }
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