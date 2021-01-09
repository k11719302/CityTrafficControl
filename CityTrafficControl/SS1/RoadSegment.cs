﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficControlAndDetection
{
    class RoadSegment
    {
        private RoadTypes type;
        public RoadTypes Type { get=>type; }

        private int id;
        public int Id { get => id; }

        private Position start;
        public Position Start { get => start; }

        private Position end;
        public Position End { get => end; }

        private RoadStates state;
        public RoadStates State { get => state; set => state = value; }

        private int numOfLanes;
        public int NumOfLanes { get => numOfLanes; }

        private int speedLimit;
        public int SpeedLImit { get => speedLimit; set => speedLimit = value; }

        private int crossroadId;
        public int CrossroadId { get => crossroadId; }

        public RoadSegment()
        {
            type = RoadTypes.EXPRESSWAY;
            id = -1;    //shows that a valid id is missing
            start = null;
            end = null;
            state = RoadStates.FREE;
            numOfLanes = 2;
            speedLimit = 60;
            crossroadId = -1;
        }

        public RoadSegment (RoadTypes type, int id, Position start, Position end, RoadStates state, int numOfLanes, int speedLimit, int crossroadId)
        {
            this.type = type;
            this.id = id;
            this.start = start;
            this.end = end;
            this.state = state;
            this.numOfLanes = numOfLanes;
            this.speedLimit = speedLimit;
            this.crossroadId = crossroadId;
        }

        public void PrintRoad()
        {
            Console.WriteLine("road segment " + id + ": " + state+", "+speedLimit+"km/h");
        }
    }

    public enum RoadTypes
    {
        HIGHWAY,
        EXPRESSWAY,
        BRIDGE,
        TUNNEL
    }

    public enum RoadStates
    {
        BLOCKED,
        FREE
    }
}