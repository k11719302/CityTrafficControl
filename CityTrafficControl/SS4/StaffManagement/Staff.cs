using CityTrafficControl.SS4.StaffManagement.EquipmentManagement;
using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4.StaffManagement {
    class Staff {
        private Dictionary<int, Team> Teams;
        private Dictionary<int, Tool> Tools;
        private Dictionary<int, Vehicle> Vehicles;
    
        public Staff() {
            this.Teams = new Dictionary<int, Team>();
            this.Tools = new Dictionary<int, Tool>();
            this.Vehicles = new Dictionary<int, Vehicle>();
        }

        public void CreateTeam(Team team) {
            Teams.Add(team.GetTeamID(), team);
        }

        public bool IsReady(Team team) {
            return team.HasEnoughManpower() && !team.IsOnMission();
        }

        public bool IsReady(Equipment equipment) {
            return equipment.IsFunctional() && !equipment.IsOnMission();
        }

        public void OrderTool(Tool tool) {
            Tools.Add(tool.GetEquipmentID(), tool);
        }

        public void OrderVehicle(Vehicle vehicle) {
            Vehicles.Add(vehicle.GetEquipmentID(), vehicle);
        }

        public Dictionary<int, Team> GetTeams() {
            return Teams;
        }

        public Dictionary<int, Tool> GetTools() {
            return Tools;
        }

        public Dictionary<int, Vehicle> GetVehicle() {
            return Vehicles;
        }
    }
}