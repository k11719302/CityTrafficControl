using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4 {
    class RoadMaintenanceService {
        private Staff Staff;
        private Dictionary<int, Schedule> Schedules;

        public RoadMaintenanceService() {
            this.Staff = new Staff();
            this.Schedules = new Dictionary<int, Schedule>();
        }

        public void SendSchedules() {
            // TODO DataLinker.sendMyData(Schedules);
        }

        public void ReceiveData() { // TODO
            throw new NotImplementedException();
        }

        public List<RoadMaintenanceTask> GetCurrentOperations() {
           if (!Schedules.Any()) {
                return null;
           }
            List<RoadMaintenanceTask> currentOps = new List<RoadMaintenanceTask>();
            DateTime currentTime = DateTime.Now; 
            foreach (Schedule s in Schedules) {
                if (OperationIsRunning(s, currentTime)) {
                    currentOps.Add(s.GetRoadMaintenanceTask())
                }
            }
            return currentOps;
        }

        private boolean OperationIsRunning(Schedule schedule, DateTime now) {
            if (schedule.GetFrom() <= now && now <= schedule.GetTo()) {
                return true;
            } else {
                return false;
            }

        }

        public void CreateScheduledTask(RoadMaintenanceTask roadMaintenanceTask, Team team, Equipment equipment, DateTime from, DateTime to) {
            // TODO Add params, check task for Type, null...
            roadMaintenanceTask.AssignEquipment(equipment);
            roadMaintenanceTask.AssignTeam(team);
            // Schedules.Add();
        }

        public void OrderReinforcements(int scheduledID, Equipment equipment, Team team) {
            RoadMaintenanceTask task = Schedules[scheduledID].GetRoadMaintenanceTask();
            if (task == null) {
                throw new ArgumentException("Task cannot be null");
            }

            if (equipment != null) {
                task.AssignEquipment(equipment);
            }

            if (team != null) {
                task.AssignTeam(team);
            }
        }
    }
}