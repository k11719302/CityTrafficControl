using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS1
{
    public class Camera : Sensor
    {
        private int id;
        public int Id { get { return id; } }

        private Coordinate position;
        public Coordinate Position { get { return position; } }

        private States state;
        public States State { get { return state; } set { state = value; } }

        private Object currentImage = null;
        public Object CurrentImage { get { return currentImage; } } // type will be adapted in Milestone 3.2

        public Camera(int id, Coordinate position) {
            this.id = id;
            this.position = position;
            State = States.INACTIVE;
        }

    }
}
