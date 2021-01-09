using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficControlAndDetection
{
    class TrafficLight
    {
        private int id;
        public int Id { get => id; }

        private Position position;
        public Position Position { get => position; }

        private LightStates state;
        public LightStates State { get => state; set => state = value; }

        private int crossroadId;
        public int CrossroadId { get => crossroadId; }

        public TrafficLight()
        {
            id = -1; //shows, that a valid id is missing
            position = null;
            state = LightStates.RED;
            crossroadId = -1; //shows, that a valid id is missing
        }

        public TrafficLight (int id, Position pos, LightStates state, int crossRoadId)
        {
            this.id = id;
            position = pos;
            this.state = state;
            this.crossroadId = crossRoadId;
        }

        public void PrintLight()
        {
            Console.WriteLine("light " + id + ": " + state);
        }
    }

    public enum LightStates
    {
        RED,
        GREEN
    }
}
