using System;

namespace CityTrafficControl.SS4.StaffManagement.EquipmentManagement {
    class Vehicle : Equipment {
        private Double FuelStatus;

        public Vehicle(int equipmentID, string equipmentType) : base(equipmentID, equipmentType) {
            this.FuelStatus = 100.0;
        }

        public override bool IsFunctional() { 
            return Durability > 25.0 && FuelStatus > 50;
        }

        public override bool SendToMaintenance() {
            if (!InMaintenance) {
                InMaintenance = true;
                return true;
            } else {
                return false;
            }
        }

        public override bool GetFromMaintenance() {
            if (InMaintenance) {
                Durability = 100.0;
                FuelStatus = 100.0;
                InMaintenance = false;
                return true;
            } else {
                return false;
            }
        }

        public Double GetFuelStatus() {
            return FuelStatus;
        }
    }
}