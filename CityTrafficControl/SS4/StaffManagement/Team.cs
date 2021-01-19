using System;
using System.Collections.Generic;

namespace CityTrafficControl.SS4.StaffManagement {

    /// <summary>
    /// Basic Class of a team
    /// </summary>
    public class Team {
        private Dictionary<int, Person> Workers;
        private readonly int TeamID;
        private int Amount;
        private bool OnMission;


        /// <summary>
        /// Creates a team object.
        /// </summary>
        /// <param name="teamID">The ID for the team.</param>
        public Team(int teamID) {
            this.Workers = new Dictionary<int, Person>();
            this.TeamID = teamID;
            this.Amount = 0;
            this.OnMission = false;
        }

        /// <summary>
        /// Creates a team object.
        /// </summary>
        /// <param name="workers">All workers which are in this team.</param>
        /// <param name="teamID">The ID for the team.</param>
        public Team(Dictionary<int, Person> workers, int teamID) {
            this.Workers = workers;
            this.TeamID = teamID;
            this.Amount = workers.Count;
            this.OnMission = false;
        }

        /// <summary>
        /// Adds a person to the team.
        /// </summary>
        /// <param name="person">The person which is added.</param>
        public void AddWorker(Person person) {
            Workers.Add(person.GetPersonID(), person);
            Amount++;
        }


        /// <summary>
        /// Removes a person of the team.
        /// </summary>
        /// <param name="personID">The ID of the person.</param>
        /// <returns>A bool which shows whether the removal worked or not.</returns>
        public Boolean RemoveWorker(int personID) {
            if (Workers.ContainsKey(personID)) {
                Workers.Remove(personID);
                Amount--;
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Defines the manpower of the team.
        /// </summary>
        /// <returns>A bool which decides, whether the team has enough manpower or not.</returns>
        public bool HasEnoughManpower() { // At least 50% of the team's workers must be operational to be ready
            int readyWorkers = 0;
            foreach (var worker in Workers) {
                if (worker.Value.IsOperational()) {
                    readyWorkers++;
                }
            }
            return (readyWorkers / Workers.Count) >= 0.5 && readyWorkers >= 1;
        }

        /// <summary>
        /// Returns a dictionary of all workers in the team.
        /// </summary>
        /// <returns>A dictionary of workers as values and integer as keys.</returns>
        public Dictionary<int, Person> GetWorkers() {
            return Workers;
        }

        /// <summary>
        /// Get the ID of the team.
        /// </summary>
        /// <returns>An integer which is the ID of the team.</returns>
        public int GetTeamID() {
            return TeamID;
        }

        /// <summary>
        /// Get the amount of the team.
        /// </summary>
        /// <returns>An integer which is the amount.</returns>
        public int GetAmount() {
            return Amount;
        }

        /// <summary>
        /// Specifies if the team is on mission or not.
        /// </summary>
        /// <returns>A bool which specifies whether the team is on mission or not.</returns>
        public bool IsOnMission() {
            return OnMission;
        }

        /// <summary>
        /// Set that the team is on mission.
        /// </summary>
        /// <param name="OnMission">The flag which sets the team on mission or not.</param>
        public void SetOnMission(bool OnMission) {
            this.OnMission = OnMission;
        }
    }
}