using System;

namespace CityTrafficControl.SS4.Staff {
    class Person {
        private readonly int PersonID;
        private readonly string Name;
        private string Specialisation;
        private bool Operational;

        public Person(int personID, string name, string specialisation) {
            this.PersonID = personID;
            this.Name = name;
            this.Specialisation = specialisation;
            this.Operational = true;
        }

        public int GetPersonID() {
            return PersonID;
        }

        public string GetName() {
            return Name;
        }

        public string GetSpecialisation() {
            return Specialisation;
        }

        public void SetSpecialisation(string specialisation) {
            this.Specialisation = specialisation;
        }

        public bool IsOperational() {
            return Operational;
        }

        public void SetOperational(bool operational) {
            this.Operational = operational;
        }
    }
}