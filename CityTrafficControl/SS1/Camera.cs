using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficControlAndDetection
{
    class Camera : Sensor
    {
        private int id;
        public int Id { get { return id; } }

        private Position position;
        public Position Position { get { return position; } }

        private States state;
        public States State { get { return state; } set { state = value; } }

        private Object currentImage = null;
        public Object CurrentImage { get { return currentImage; } } // type will be adapted in Milestone 3.2

        public Camera(int id, Position position) {
            this.id = id;
            this.position = position;
            State = States.INACTIVE;
        }

    }
}
