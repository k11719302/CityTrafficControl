using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4.Staff {
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
            return TeamReadyCheck(team) && team.IsOnMission();
        }

        private bool TeamReadyCheck(Team team) { // At least 50% of the team's workers must be operational to be ready
            int readyWorkers = 0;
            foreach (var worker in team.GetWorkers()) {
                if (worker.Value.IsOperational()) {
                    readyWorkers++;
                }
            }
            return (readyWorkers/team.GetWorkers().Count) >= 0.5;
        }

        public bool IsFunctional(Equipment equipment) { // Durability must be higher than 25% and Fuel must be higher than 50% to be functional
            if (equipment.GetType() == typeof(Vehicle)) {
                Vehicle vehicle = (Vehicle) equipment;
                return vehicle.GetDurability() > 25.0 && vehicle.GetFuelStatus() > 50.0;  
            } else {
                return equipment.GetDurability() > 25.0;
            }
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