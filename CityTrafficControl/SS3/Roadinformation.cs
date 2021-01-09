﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    class Roadinformation
    {
        private int roadId;
        private int speedlimit;
        private RoadStatus status;

        public Roadinformation(int roadId)
        {
            this.roadId = roadId;
            speedlimit = receiveCurrSpeedLimit();
            status = receiveCurrRoadStatus();
        }

        public int RoadId { get => roadId; }
        public int Speedlimit { get => speedlimit; }
        public RoadStatus Status { get => status; }

        //receive current data from datalinker
        public int receiveCurrSpeedLimit()
        {
            throw new NotImplementedException();
        }
        public RoadStatus receiveCurrRoadStatus()
        {
            throw new NotImplementedException();
        }

    }
}