using CityTrafficControl.SS4.Staff;
using CityTrafficControl.SS4.Staff.Equipment;
using CityTrafficControl.SS4.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityTrafficControl.SS4 {
    class RoadMaintenanceService {
        private Staff.Staff Staff;
        private Dictionary<int, Schedule> Schedules;
        private static int IDCounter;

        public RoadMaintenanceService() {
            this.Staff = new Staff.Staff();
            this.Schedules = new Dictionary<int, Schedule>();
            this.IDCounter = 0;
        }

        public void SendSchedules() {
            // TODO DataLinker.sendMyData(Schedules);
        }

        public void ReceiveData() { // TODO
            throw new NotImplementedException();
        }

        public List<Schedule> GetCurrentOperations() {
			if (Schedules.Count == 0) {		
				return null;
            }
            List<Schedule> currentOps = new List<RoadMaintenanceTask>();
            DateTime currentTime = DateTime.Now; 
            foreach (Schedule s in Schedules.Values) { 
				if (OperationIsRunning(s, currentTime)) {
					currentOps.Add(s);
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

        public void CreateScheduledTask(RoadMaintenanceTask roadMaintenanceTask) {
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
                equipment.SetOnMission(true);
            }

            if (team != null) {
                task.AssignTeam(team);
                team.SetOnMission(true);
            }
        }
    }
}