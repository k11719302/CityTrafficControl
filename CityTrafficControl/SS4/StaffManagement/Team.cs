using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4.StaffManagement {
    class Team {
        private Dictionary<int, Person> Workers;
        private readonly int TeamID;
        private int Amount;
        private bool OnMission;

        public Team(int teamID) {
            this.Workers = new Dictionary<int, Person>();
            this.TeamID = teamID;
            this.Amount = 0;
            this.OnMission = false;
        }

        public Team(Dictionary<int, Person> workers, int teamID) {
            this.Workers = workers;
            this.TeamID = teamID;
            this.Amount = workers.Count;
            this.OnMission = false;
        }

        public void AddWorker(Person person) {
            Workers.Add(person.GetPersonID(), person); 
        }

        public Boolean RemoveWorker(int personID) {
            if (Workers.ContainsKey(personID)) {
                Workers.Remove(personID);
                return true;
            } else {
                return false;
            }
        }

        public Dictionary<int, Person> GetWorkers() {
            return Workers;
        }

        public int GetTeamID() {
            return TeamID;
        }

        public int GetAmount() {
            return Amount;
        }

        public bool IsOnMission() {
            return OnMission;
        }

        public void SetOnMission(bool OnMission) {
            this.OnMission = OnMission;
        }
    }
}