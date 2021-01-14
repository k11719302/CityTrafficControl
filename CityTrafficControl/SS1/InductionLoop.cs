using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS1
{
    public class InductionLoop : Sensor
    {
        private int id;
        public int Id { get { return id; } } //should not be changed

        private Coordinate position; 
        public Coordinate Position { get { return position; } } //position could change in case of e.g. moving the induction loop to another road segment

        private States state; //states are defined with the enumeration
        public States State { get { return state; } set { state = value; } }

        private bool participantWaiting;
        public bool ParticipantWaiting { get; set; }

        public InductionLoop(int id, Coordinate position)
        {
            this.id = id;
            this.position = position;
            state = States.INACTIVE;
            ParticipantWaiting = false;
        }
    }
}
