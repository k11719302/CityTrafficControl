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

        /// <summary>
        /// Creates a RoadMaintenanceService object with staff and schedules.
        /// </summary>
        public RoadMaintenanceService() {
            this.Staff = new Staff();
            this.Schedules = new Dictionary<int, Schedule>();
        }

        /// <summary>
        /// The method which sends the schedules via the DataLinker
        /// </summary>
        public void SendSchedules() {
            DataLinker.SS4.SendSchedules(GetSchedules());
        }

        /// <summary>
        /// Creates an accident task.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        /// <param name="numberOfVehicles">Shows the amount of vehicles.</param>
        /// <param name="roadDamage">Shows whether the road is damaged or not.</param>
        /// <param name="from">From when does this task start.</param>
        /// <param name="to">When does the task approx. end.</param>
        public void CreateAccidentTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, int numberOfVehicles, bool roadDamage, DateTime from, DateTime to) {
            RoadMaintenanceTask task = new Accident(taskName, taskDescription, streetConnectors, priority, numberOfVehicles, roadDamage);
            ScheduleTask(task, from, to);
        }

        /// <summary>
        /// Creates a natural disaster task.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        /// <param name="disasterType">Specifies the type of disaster.</param>
        /// <param name="roadDamage">Shows whether the road is damaged or not.</param>
        /// <param name="blockages">Specifies the number of blockages.</param>
        /// <param name="from">From when does this task start.</param>
        /// <param name="to">When does the task approx. end.</param>
        public void CreateNaturalDisasterTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, string disasterType, bool roadDamage, int blockages,  DateTime from, DateTime to) {
            RoadMaintenanceTask task = new NaturalDisaster(taskName, taskDescription, streetConnectors, priority, disasterType, roadDamage, blockages);
            ScheduleTask(task, from, to);
        }

        /// <summary>
        /// Creates an inspection task.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        /// <param name="from">From when does this task start.</param>
        /// <param name="to">When does the task approx. end.</param>
        public void CreateInspectionTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, DateTime from, DateTime to) {
            RoadMaintenanceTask task = new Inspection(taskName, taskDescription, streetConnectors, priority);
            ScheduleTask(task, from, to);
        }

        /// <summary>
        /// Creates a maintenance task.
        /// </summary>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="taskDescription">String which describes the task.</param>
        /// <param name="streetConnectors">A List of all connectors.</param>
        /// <param name="priority">Shows the priority of the task.</param>
        /// <param name="roadDamage">Shows whether the road is damaged or not.</param>
        /// <param name="from">From when does this task start.</param>
        /// <param name="to">When does the task approx. end.</param>
        public void CreateMaintenanceTask(string taskName, string taskDescription, List<StreetConnector> streetConnectors, int priority, bool roadDamage, DateTime from, DateTime to) {
            RoadMaintenanceTask task = new Maintenance(taskName, taskDescription, streetConnectors, priority, roadDamage);
            ScheduleTask(task, from, to);
        }

        /// <summary>
        /// Schedules a given task.
        /// </summary>
        /// <param name="task">The given task which should be scheduled.</param>
        /// <param name="from">Defines when the task should start.</param>
        /// <param name="to">Defines when the task should end.</param>
        private void ScheduleTask(RoadMaintenanceTask task, DateTime from, DateTime to) {
            Schedule schedule = new Schedule(IDCounter++, task, from, to);
            Schedules.Add(schedule.GetScheduleID(), schedule);
        }


        /// <summary>
        /// Returns all schedules in a list.
        /// </summary>
        /// <returns>A list of schedules</returns>
        public List<Schedule> GetSchedules() {
            return Schedules.Values.ToList<Schedule>();
        }

        /// <summary>
        /// Retturns all current operations in a list.
        /// </summary>
        /// <returns>A list of current operations</returns>
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

        /// <summary>
        /// Shows whether an operation is running or not.
        /// </summary>
        /// <param name="schedule">The specified schedule.</param>
        /// <param name="now">The current time.</param>
        /// <returns>A bool which specifies if the operation is running or not.</returns>
        private bool OperationIsRunning(Schedule schedule, DateTime now) {
            if (schedule.GetFrom() <= now && now <= schedule.GetTo()) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Orders the specified (ID, team) reinforcement.
        /// </summary>
        /// <param name="scheduleID">The ID of the current schedule.</param>
        /// <param name="team">The specified team.</param>
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

        /// <summary>
        /// Orders equipment as reinforcement.
        /// </summary>
        /// <param name="scheduleID">The ID of the current schedule.</param>
        /// <param name="equipment">The equipment which is needed.</param>
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