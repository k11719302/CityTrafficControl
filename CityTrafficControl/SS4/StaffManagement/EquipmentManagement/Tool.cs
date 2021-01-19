using System;

namespace CityTrafficControl.SS4.StaffManagement.EquipmentManagement {

    /// <summary>
    /// Class for a specified Tool.
    /// </summary>
    public class Tool : Equipment {

        /// <summary>
        /// Creates a Tool.
        /// </summary>
        /// <param name="equipmentID">ID of the Tool.</param>
        /// <param name="equipmentType">Type of the Tool.</param>
        public Tool(int equipmentID, String equipmentType) : base(equipmentID, equipmentType) {
        }
    }
}