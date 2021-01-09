using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    static class ControlSystem
    {
        private static List<Path> paths;
        private static List<Road> roads;
        private static List<Intersection> intersections;
        private static List<TrafficParticipant> participants;

        //Todo: receive data from datalinker
        public static void ReceiveMaintSchedules()
        {
            throw new NotImplementedException();
        }

        public static void ReceiveParticipantsPosition()
        {
            throw new NotImplementedException();
        }

        //Todo: send data to datalinker

        //Datalinker.blockRoads(data);

        //Datalinker.sendBaseRoutes(data);

        //Datalinker.setSpeedLimits(data);

        //Datalinker.SetTrafficLights(data);

        //Datalinker.SetIncidentInfo(data)

    }
}
