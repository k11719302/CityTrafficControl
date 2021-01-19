using CityTrafficControl.SS4.Tasks;
using System;

namespace CityTrafficControl.SS4 {

    /// <summary>
    /// The Schedule where all tasks are stored.
    /// </summary>
    public class Schedule {
        private readonly int ScheduleID;
        private RoadMaintenanceTask RoadMaintenanceTask;
        private DateTime From;
        private DateTime To;
        private Double Progress;


        /// <summary>
        /// Creates a new schedule.
        /// </summary>
        /// <param name="scheduleID">ID for the current task.</param>
        /// <param name="roadMaintenanceTask">The actual task.</param>
        /// <param name="from">Time where the task should start.</param>
        /// <param name="to">Time where the task should end.</param>
        public Schedule(int scheduleID, RoadMaintenanceTask roadMaintenanceTask, DateTime from, DateTime to) {
            this.ScheduleID = scheduleID;
            this.RoadMaintenanceTask = roadMaintenanceTask;
            this.From = from;
            this.To = to;
            this.Progress = 0.0;
        }

        /// <summary>
        /// Get the ID of the schedule.
        /// </summary>
        /// <returns>The ID of the schedule.</returns>
        public int GetScheduleID() {
            return ScheduleID;
        }

        /// <summary>
        /// Get the RoadMaintenanceTask.
        /// </summary>
        /// <returns>The RoadMaintenanceTask.</returns>
        public RoadMaintenanceTask GetRoadMaintenanceTask() {
            return RoadMaintenanceTask;
        }

        /// <summary>
        /// Get the time when the schedule should start.
        /// </summary>
        /// <returns>The time when the schedule should start.</returns>
        public DateTime GetFrom() {
            return From;
        }

        /// <summary>
        /// Set the time when the schedule should start.
        /// </summary>
        /// <param name="from">The time when the schedule should start.</param>
        public void SetFrom(DateTime from) {
            this.From = from;
        }

        /// <summary>
        /// Get the time when the schedule should end.
        /// </summary>
        /// <returns>The time when the schedule should end.</returns>
        public DateTime GetTo() {
            return To;
        }

        /// <summary>
        /// Set the time when the schedule should end.
        /// </summary>
        /// <param name="to">The time when the schedule should end.</param>
        public void SetTo(DateTime to) {
            this.To = to;
        }

        /// <summary>
        /// Get the progress.
        /// </summary>
        /// <returns>The progress.</returns>
        public Double GetProgress() {
            return Progress;
        }


        /// <summary>
        /// Set the progress.
        /// </summary>
        /// <param name="progress">Progress which is set.</param>
        public void SetProgress(Double progress) {
            if (0 <= progress && progress <= 100) {
                this.Progress = progress;
            } else {
                throw new ArgumentException("Progress cannot be smaller than 0.0% or higher than 100.0%");
            }
            
        }
    }
}