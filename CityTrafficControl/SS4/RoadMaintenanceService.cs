using CityTrafficControl.SS4.StaffManagement;
using CityTrafficControl.SS4.StaffManagement.EquipmentManagement;
using CityTrafficControl.SS4.Tasks;
using System;
using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;
using System.Linq;
using CityTrafficControl.Master;

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
            DataLinker.SS4.SendSchedules(GetSchedules());
        }

        public void CreateAccidentTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, int numberOfVehicles, bool roadDamage, DateTime from, DateTime to) {
            RoadMaintenanceTask task = new Accident(taskName, taskDescription, streetConnectors, priority, numberOfVehicles, roadDamage);
            ScheduleTask(task, from, to);
        }

        public void CreateNaturalDisasterTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, string disasterType, bool roadDamage, int blockages,  DateTime from, DateTime to) {
            RoadMaintenanceTask task = new NaturalDisaster(taskName, taskDescription, streetConnectors, priority, disasterType, roadDamage, blockages);
            ScheduleTask(task, from, to);
        }

        public void CreateInspectionTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, DateTime from, DateTime to) {
            RoadMaintenanceTask task = new Inspection(taskName, taskDescription, streetConnectors, priority);
            ScheduleTask(task, from, to);
        }

        public void CreateMaintenanceTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, bool roadDamage, DateTime from, DateTime to) {
            RoadMaintenanceTask task = new Maintenance(taskName, taskDescription, streetConnectors, priority, roadDamage);
            ScheduleTask(task, from, to);
        }

        private void ScheduleTask(RoadMaintenanceTask task, DateTime from, DateTime to) {
            Schedule schedule = new Schedule(IDCounter++, task, from, to);
            Schedules.Add(schedule.GetScheduleID(), schedule);
        }

        public List<Schedule> GetSchedules() {
            return Schedules.Values.ToList<Schedule>();
        }

        public List<Schedule> GetCurrentOperations() {
            if (Schedules.Count == 0) {
                return null;
            }
            List<Schedule> currentOps = new List<Schedule>();
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

        public void OrderTeamReinforcement(int scheduledID, Team team) {
            RoadMaintenanceTask task = Schedules[scheduledID].GetRoadMaintenanceTask();
            if (task == null) {
                throw new ArgumentException("Task cannot be null");
            }

            if (team != null && Staff.IsReady(team)) {
                task.AssignTeam(team);
                team.SetOnMission(true);
            }
        }

        public void OrderEquipmentReinforcement(int scheduledID, Equipment equipment) {
            RoadMaintenanceTask task = Schedules[scheduledID].GetRoadMaintenanceTask();
            if (task == null) {
                throw new ArgumentException("Task cannot be null");
            }

            if (equipment != null && Staff.IsReady(equipment)) {
                task.AssignEquipment(equipment);
                equipment.SetOnMission(true);
            }
        }
    }
}