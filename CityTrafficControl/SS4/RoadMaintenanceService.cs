using CityTrafficControl.SS4.StaffManagement;
using CityTrafficControl.SS4.StaffManagement.EquipmentManagement;
using CityTrafficControl.SS4.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityTrafficControl.SS4 {
    class RoadMaintenanceService {
        private Staff Staff;
        private Dictionary<int, Schedule> Schedules;
        private static int IDCounter = 0;

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
			if (Schedules.Count == 0) {	
				return null;
            }
            List<RoadMaintenanceTask> currentOps = new List<RoadMaintenanceTask>();
            DateTime currentTime = DateTime.Now; 
            foreach (Schedule s in Schedules.Values) {    
				if (OperationIsRunning(s, currentTime)) {
					currentOps.Add(s.GetRoadMaintenanceTask());
                }
            }
            return currentOps;
        }

        private bool OperationIsRunning(Schedule schedule, DateTime now) {
            if (schedule.GetFrom() <= now && now <= schedule.GetTo()) {
                return true;
            } else {
                return false;
            }

        }

        public void CreateScheduledTaskFromData(RoadMaintenanceTask roadMaintenanceTask) {
            // Take data from SS1 and convert it into a schedule
            // Schedules.Add();
        }

        public void OrderReinforcements(int scheduledID, Equipment equipment, Team team) {
            RoadMaintenanceTask task = Schedules[scheduledID].GetRoadMaintenanceTask();
            if (task == null) {
                throw new ArgumentException("Task cannot be null");
            }

            if (equipment != null) {
                task.AssignEquipment(equipment);
                equipment.SetOnMission(true);
            }

            if (team != null) {
                task.AssignTeam(team);
                team.SetOnMission(true);
            }
        }
    }
}