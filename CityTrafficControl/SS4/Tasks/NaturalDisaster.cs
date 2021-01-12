using System;

namespace CityTrafficControl.SS4.Tasks {
    class NaturalDisaster : RoadMaintenanceTask {
        private string DisasterType;
        private bool RoadDamage;
        private int Blockages;

        public NaturalDisaster(string taskName, string taskDecription, int priority, string disasterType, bool roadDamage, int blockages) 
        : base(taskName, taskDecription, priority) {
            this.DisasterType = disasterType;
            this.RoadDamage = roadDamage;
            this.Blockages = blockages;
        }

        public string getDisasterType() {
            return DisasterType;
        }

        public bool getRoadDamage() {
            return RoadDamage;
        }

        public int getBlockages() {
            return Blockages;
        }
    }
}