using System;

namespace CityTrafficControl.SS4.StaffManagement {

    /// <summary>
    /// Basic class for persons.
    /// </summary>
    public class Person {
        private readonly int PersonID;
        private readonly string Name;
        private string Specialisation;
        private bool Operational;


        /// <summary>
        /// Creates a Person object.
        /// </summary>
        /// <param name="personID">ID corresponding to the person.</param>
        /// <param name="name">Name of the Person.</param>
        /// <param name="specialisation">Specisalisation of the person.</param>
        public Person(int personID, string name, string specialisation) {
            this.PersonID = personID;
            this.Name = name;
            this.Specialisation = specialisation;
            this.Operational = true;
        }

        /// <summary>
        /// Get the ID of the person.
        /// </summary>
        /// <returns>The ID of the person.</returns>
        public int GetPersonID() {
            return PersonID;
        }

        /// <summary>
        /// Get the name of the person.
        /// </summary>
        /// <returns>The name of the person.</returns>
        public string GetName() {
            return Name;
        }

        /// <summary>
        /// Get the specialisation of the person.
        /// </summary>
        /// <returns>The specialisation of the person.</returns>
        public string GetSpecialisation() {
            return Specialisation;
        }

        /// <summary>
        /// Set the specialisation of the person.
        /// </summary>
        /// <param name="specialisation">The specialisation which is assigned.</param>
        public void SetSpecialisation(string specialisation) {
            this.Specialisation = specialisation;
        }

        /// <summary>
        /// Get whether the person is operational or not.
        /// </summary>
        /// <returns>A bool which shows whether the person is operational or not.</returns>
        public bool IsOperational() {
            return Operational;
        }


        /// <summary>
        /// Set whether the person is operational or not.
        /// </summary>
        /// <param name="operational">The flag which decides whether the person is operational or not.</param>
        public void SetOperational(bool operational) {
            this.Operational = operational;
        }
    }
}