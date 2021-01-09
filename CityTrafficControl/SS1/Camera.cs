using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficControlAndDetection
{
    class Camera : Sensor
    {
        private int id;
        public int Id { get => id; }

        private Position position;
        public Position Position { get => position; }

        private States state;
        public States State { get => state; set => state = value; }

        private Object currentImage = null;
        public Object CurrentImage { get=> currentImage; } // type will be adapted in Milestone 3.2

        public Camera(int id, Position position) {
            this.id = id;
            this.position = position;
            State = States.INACTIVE;
        }

    }
}
