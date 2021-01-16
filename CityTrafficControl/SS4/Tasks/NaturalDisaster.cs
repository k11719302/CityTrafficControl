using System.Collections.Generic;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS4.Tasks {
    class NaturalDisaster : RoadMaintenanceTask {
        private string DisasterType;
        private bool RoadDamage;
        private int Blockages;

        public NaturalDisaster(string taskName, string taskDecription, List<StreetConnector> streetConnectors, int priority, string disasterType, bool roadDamage, int blockages) 
        : base(taskName, taskDecription, streetConnectors, priority) {
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