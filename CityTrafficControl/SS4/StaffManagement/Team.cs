using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4.StaffManagement {
    public class Team {
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
            Amount++;
        }

        public Boolean RemoveWorker(int personID) {
            if (Workers.ContainsKey(personID)) {
                Workers.Remove(personID);
                Amount--;
                return true;
            } else {
                return false;
            }
        }

        public bool HasEnoughManpower() { // At least 50% of the team's workers must be operational to be ready
            int readyWorkers = 0;
            foreach (var worker in Workers) {
                if (worker.Value.IsOperational()) {
                    readyWorkers++;
                }
            }
            return (readyWorkers / Workers.Count) >= 0.5 && readyWorkers >= 1;
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