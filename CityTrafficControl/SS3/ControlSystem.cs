using System;
using CityTrafficControl.SS4;
using CityTrafficControl.Master.StreetMap;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    static class ControlSystem
    {
        private static List<Master.DataStructures.BaseRoute> paths;
        private static List<Intersection> intersectionsPlans;
        private static List<Schedule> schedules;

        static ControlSystem()
        {
            paths = new List<Master.DataStructures.BaseRoute>();
            intersectionsPlans = new List<Intersection>();
            schedules = new List<Schedule>();
        }


        /// <summary>
        /// Block Street segments if Maintenance work need to be done and unblock and delete from schedules 
        /// when done.
        /// </summary>        
        public static void CheckSchedules()
        {
            foreach(Schedule s in schedules)
            {
                if (Master.SimulationManager.CurTickTime.Subtract(s.GetFrom()).CompareTo(TimeSpan.Zero) > 0)
                {
                    //BlockRoads(s.GetRoadMaintenanceTask());
                }
                if (Master.SimulationManager.CurTickTime.Subtract(s.GetTo()).CompareTo(TimeSpan.Zero) > 0)
                {
                    //Unblock
                    schedules.Remove(s);
                }
            }
        }

        private static List<StreetSegment> GetConnectingStreetSegments(List<StreetConnector> connectors)
        {
            StreetType t;
            List<StreetSegment> s = new List<StreetSegment>();
            foreach(StreetConnector sc1 in connectors)
            {
                foreach(StreetConnector sc2 in connectors)
                {
                    if(sc1 != sc2 && sc1.FindNeighbours().Contains(sc2))
                    {
                        if(sc1.EP1.FindNeighbours().Contains(sc2))
                        {
                            t = sc1.EP1.Self;
                        }
                        else
                        {
                            t = sc1.EP2.Self;
                        }
                        if (t is StreetSegment)
                        {
                            StreetSegment segment = (StreetSegment)t;
                            if(!s.Contains(segment))
                            {
                                s.Add(segment);
                            }
                        }
                    }
                   
                }
            }
            return s;
        }

        public static void BlockRoads(List<StreetConnector> connectors)
        {
            List<StreetSegment> segments = GetConnectingStreetSegments(connectors);
            foreach (StreetSegment s in segments)
            {
                if (s.IsUsable)
                {
                    RoadInstruction ri = new RoadInstruction(s.ID, s.SpeedLimit, false);
                    SendRoadInstruction(ri);
                }
            }
        }
        public static void UnblockRoads(List<StreetConnector> connectors)
        {
            List<StreetSegment> segments = GetConnectingStreetSegments(connectors);
            foreach (StreetSegment s in segments)
            {
                if (!s.IsUsable)
                {
                    RoadInstruction ri = new RoadInstruction(s.ID, s.SpeedLimit, true);
                    SendRoadInstruction(ri);
                }
            }
        }

        public static void SetSpeedlimit(StreetSegment segment, double speedlimit)
        {
            if(segment.SpeedLimit != speedlimit)
            {
                RoadInstruction ri = new RoadInstruction(segment.ID, speedlimit, true);
                SendRoadInstruction(ri);
            }
        }

        public static void AddIntersectionPlans(Intersection plan)
        {
            if(FindIntersectionPlan(plan.Id) != null)
            {
                intersectionsPlans.Remove(FindIntersectionPlan(plan.Id));  
            }
            intersectionsPlans.Add(plan);
        }

        private static Intersection FindIntersectionPlan(int id)
        {
            return intersectionsPlans.Find(x => x.Id == id);
        }

        //receive data from datalinker
        public static void ReceiveMaintSchedules()
        {
            throw new NotImplementedException();
        }


        //Send to Datalinker
        public static void SendIntersectionPlan()
        {
            //Datalinker.
        }
        public static void SendBaseRoute()
        {
            //Datalinker.
        }

        public static void SendRoadInstruction(RoadInstruction r)
        {
            //Datalinker.
        }

    }
}
