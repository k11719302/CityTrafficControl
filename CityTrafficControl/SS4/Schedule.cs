using System;

namespace CityTrafficControl.SS4 {
    class Schedule {
        private readonly int ScheduleID;
        private RoadMaintenanceTask RoadMaintenanceTask;
        private DateTime From;
        private DateTime To;
        private Double Progress;

        public Schedule(int scheduleID, RoadMaintenanceTask roadMaintenanceTask, DateTime from, DateTime to, Double progress) {
            this.ScheduleID = scheduleID;
            this.RoadMaintenanceTask = roadMaintenanceTask;
            this.From = from;
            this.To = to;
            this.Progress = progress;
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
            this.Progress = progress;
        }
    }
}