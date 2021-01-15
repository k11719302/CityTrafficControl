using CityTrafficControl.SS4.Tasks;
using System;

namespace CityTrafficControl.SS4 {
    class Schedule {
        private readonly int ScheduleID;
        private RoadMaintenanceTask RoadMaintenanceTask;
        private DateTime From;
        private DateTime To;
        private Double Progress;

        public Schedule(int scheduleID, RoadMaintenanceTask roadMaintenanceTask, DateTime from, DateTime to) {
            this.ScheduleID = scheduleID;
            this.RoadMaintenanceTask = roadMaintenanceTask;
            this.From = from;
            this.To = to;
            this.Progress = 0.0;
        }
        
        public int GetScheduleID() {
            return ScheduleID;
        }

        public RoadMaintenanceTask GetRoadMaintenanceTask() {
            return RoadMaintenanceTask;
        }

        public DateTime GetFrom() {
            return From;
        }

        public void SetFrom(DateTime from) {
            this.From = from;
        }

        public DateTime GetTo() {
            return To;
        }

        public void SetTo(DateTime to) {
            this.To = to;
        }

        public Double GetProgress() {
            return Progress;
        }

        public void SetProgress(Double progress) {
            if (0 <= progress && progress <= 100) {
                this.Progress = progress;
            } else {
                throw new ArgumentException("Progress cannot be smaller than 0.0% or higher than 100.0%");
            }
            
        }
    }
}