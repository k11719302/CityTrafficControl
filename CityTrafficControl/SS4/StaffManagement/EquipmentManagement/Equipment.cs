using System;

namespace CityTrafficControl.SS4.Staff.EquipmentManagement {
    abstract class Equipment {
        private readonly int EquipmentID;
        private readonly string EquipmentType;
        protected Double Durability;
        protected bool InMaintenance;
        private bool OnMission;

        protected Equipment(int equipmentID, string equipmentType) {
            this.EquipmentID = equipmentID;
            this.EquipmentType = equipmentType;
            this.Durability = 100.0;
            this.InMaintenance = false;
            this.OnMission = false;
        }

        public virtual bool SendToMaintenance() {
            if (!InMaintenance) {
                InMaintenance = true;
                return true;
            } else {
                return false;
            }
        }

        public virtual bool GetFromMaintenance() {
            if (InMaintenance) {
                Durability = 100.0;
                InMaintenance = false;
                return true;
            } else {
                return false;
            }
        }

        public int GetEquipmentID() {
            return EquipmentID;
        }

        public string GetEquipmentType() {
            return EquipmentType;
        }

        public Double GetDurability() {
            return Durability;
        }

        public bool GetInMaintenance() {
            return InMaintenance;
        }

        public bool IsOnMission() {
            return OnMission;
        }

        public void SetOnMission(bool OnMission) {
            this.OnMission = OnMission;
        }
    }
}