using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS1
{
    public class TrafficLight
    {
        private int id;
        public int Id { get { return id; } }

        private Coordinate position;
        public Coordinate Position { get { return position; } }

        private LightStates state;
        public LightStates State { get { return state; } set { state = value; } }

        private int crossroadId;
        public int CrossroadId { get { return crossroadId; } }

        public TrafficLight()
        {
            id = -1; //shows, that a valid id is missing
            position = null;
            state = LightStates.RED;
            crossroadId = -1; //shows, that a valid id is missing
        }

        public TrafficLight (int id, Coordinate pos, LightStates state, int crossRoadId)
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
