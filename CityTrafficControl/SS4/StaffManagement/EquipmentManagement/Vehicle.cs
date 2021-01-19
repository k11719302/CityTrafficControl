using System;

namespace CityTrafficControl.SS4.StaffManagement.EquipmentManagement {

    /// <summary>
    /// Class for a specified Vehicle.
    /// </summary>
    public class Vehicle : Equipment {
        private Double FuelStatus;


        /// <summary>
        /// Creates a vehicle object.
        /// </summary>
        /// <param name="equipmentID">ID of the Vehicle.</param>
        /// <param name="equipmentType">Type of the Vehicle.</param>
        public Vehicle(int equipmentID, string equipmentType) : base(equipmentID, equipmentType) {
            this.FuelStatus = 100.0;
        }

        /// <summary>
        /// Shows whether the vehicle is functional.
        /// </summary>
        /// <returns>A bool which shows if the vehicle is functional.</returns>
        public override bool IsFunctional() { 
            return Durability > 25.0 && FuelStatus > 50;
        }

        /// <summary>
        /// Sends the vehicle to maintenance.
        /// </summary>
        /// <returns>A bool which shows if it worked or not.</returns>
        public override bool SendToMaintenance() {
            if (!InMaintenance) {
                InMaintenance = true;
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// Gets the vehicle from maintenance.
        /// </summary>
        /// <returns>A bool which shows if it worked or not.</returns>
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

        /// <summary>
        /// Get the status of the fuel.
        /// </summary>
        /// <returns>A double which shows the status of the fuel.</returns>
        public Double GetFuelStatus() {
            return FuelStatus;
        }
    }
}