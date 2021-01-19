using CityTrafficControl.SS4.StaffManagement.EquipmentManagement;
using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4.StaffManagement {

    /// <summary>
    /// Class for the staff.
    /// </summary>
    public class Staff {
        private Dictionary<int, Team> Teams;
        private Dictionary<int, Tool> Tools;
        private Dictionary<int, Vehicle> Vehicles;
    
        /// <summary>
        /// Creates a Staff object with teams, tools and vehicles.
        /// </summary>
        public Staff() {
            this.Teams = new Dictionary<int, Team>();
            this.Tools = new Dictionary<int, Tool>();
            this.Vehicles = new Dictionary<int, Vehicle>();
        }


        /// <summary>
        /// Creates a team.
        /// </summary>
        /// <param name="team">The team which should be created.</param>
        public void CreateTeam(Team team) {
            Teams.Add(team.GetTeamID(), team);
        }

        /// <summary>
        /// Shows whether a team is ready or not.
        /// </summary>
        /// <param name="team">The team which should be checked.</param>
        /// <returns>A bool which checks the manpower and whether the team is on mission or not.</returns>
        public bool IsReady(Team team) {
            return team.HasEnoughManpower() && !team.IsOnMission();
        }

        /// <summary>
        /// Shows whether an equipment is ready or not.
        /// </summary>
        /// <param name="equipment">The equipment which should be checked.</param>
        /// <returns>A bool which checks the functionality and whether the equipment is on mission or not.</returns>
        public bool IsReady(Equipment equipment) {
            return equipment.IsFunctional() && !equipment.IsOnMission();
        }

        /// <summary>
        /// Orders a specified tool.
        /// </summary>
        /// <param name="tool">The tool which is ordered.</param>
        public void OrderTool(Tool tool) {
            Tools.Add(tool.GetEquipmentID(), tool);
        }

        /// <summary>
        /// Orders a specified Vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle which is ordered.</param>
        public void OrderVehicle(Vehicle vehicle) {
            Vehicles.Add(vehicle.GetEquipmentID(), vehicle);
        }

        /// <summary>
        /// Get the teams.
        /// </summary>
        /// <returns>A dicitonary which holds all teams.</returns>
        public Dictionary<int, Team> GetTeams() {
            return Teams;
        }

        /// <summary>
        /// Get the tools.
        /// </summary>
        /// <returns>A dicitonary which holds all tools.</returns>
        public Dictionary<int, Tool> GetTools() {
            return Tools;
        }

        /// <summary>
        /// Get the vehicles.
        /// </summary>
        /// <returns>A dicitonary which holds all vehicles.</returns>
        public Dictionary<int, Vehicle> GetVehicle() {
            return Vehicles;
        }
    }
}