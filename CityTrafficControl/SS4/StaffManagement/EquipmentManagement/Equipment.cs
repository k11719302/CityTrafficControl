using System;

namespace CityTrafficControl.SS4.StaffManagement.EquipmentManagement {

    /// <summary>
    /// Basic class of an Equipment
    /// </summary>
    public abstract class Equipment {
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

        /// <summary>
        /// Sends the equipment to maintenance.
        /// </summary>
        /// <returns>A bool which shows if it worked or not.</returns>
        public virtual bool SendToMaintenance() {
            if (!InMaintenance) {
                InMaintenance = true;
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Gets the equipment from maintenance.
        /// </summary>
        /// <returns>A bool which shows if it worked or not.</returns>
        public virtual bool GetFromMaintenance() {
            if (InMaintenance) {
                Durability = 100.0;
                InMaintenance = false;
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Shows whether the equipment is functional.
        /// </summary>
        /// <returns>A bool which shows if the equipment is functional.</returns>
        public virtual bool IsFunctional() { // Durability must be higher than 25% and Fuel must be higher than 50% to be functional 
            return Durability > 25.0;
        }

        /// <summary>
        /// Get the ID of the equipment.
        /// </summary>
        /// <returns>The ID of the equipment.</returns>
        public int GetEquipmentID() {
            return EquipmentID;
        }

        /// <summary>
        /// Get the type of the equipment.
        /// </summary>
        /// <returns>The type of the equipment.</returns>
        public string GetEquipmentType() {
            return EquipmentType;
        }


        /// <summary>
        /// Get the durability of the equipment.
        /// </summary>
        /// <returns>The durability of the equipment.</returns>
        public Double GetDurability() {
            return Durability;
        }

        /// <summary>
        /// Shows if the equipment is in maintenance.
        /// </summary>
        /// <returns>The flag whether the equipment is in maintenance or not.</returns>
        public bool GetInMaintenance() {
            return InMaintenance;
        }

        /// <summary>
        /// Shows if the equipment is on mission.
        /// </summary>
        /// <returns>The flag whether the equipment is on mission or not.</returns>
        public bool IsOnMission() {
            return OnMission;
        }


        /// <summary>
        /// Change the flag of the equipment.
        /// </summary>
        /// <param name="OnMission">The flag which decides whether the equipment is on mission or not.</param>
        public void SetOnMission(bool OnMission) {
            this.OnMission = OnMission;
        }
    }
}