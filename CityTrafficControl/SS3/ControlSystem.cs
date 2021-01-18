using System;
using CityTrafficControl.SS4;
using CityTrafficControl.SS1;
using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.Master;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.DataStructures;

namespace CityTrafficControl.SS3
{
    static public class ControlSystem
    {
        private static List<BaseRoute> paths;
        private static List<TrafficLightPlan> trafficlightPlans;
        private static List<Schedule> schedules;

        static ControlSystem()
        {
            paths = new List<BaseRoute>();
            trafficlightPlans = new List<TrafficLightPlan>();
            schedules = new List<Schedule>();
            Master.DataLinker.SS3.ReceiveMaintenanceSchedules += Datalinker_ss3_ReceiveMaintenanceSchedules;
        }


        public static void ReceiveMaintenanceSchedules(List<Schedule> newSchedules)
        {
            foreach(Schedule s in newSchedules)
            {
                if(schedules.Find(x => x.GetScheduleID() == s.GetScheduleID()) == null)
                {
                    schedules.Add(s);
                }
            }
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
                    BlockRoads(s.GetRoadMaintenanceTask().GetStreetConnectors());
                }
                if (Master.SimulationManager.CurTickTime.Subtract(s.GetTo()).CompareTo(TimeSpan.Zero) > 0)
                {
                    UnblockRoads(s.GetRoadMaintenanceTask().GetStreetConnectors());
                    schedules.Remove(s);
                }
            }
        }

        public static List<StreetSegment> GetConnectingStreetSegments(List<StreetConnector> connectors)
        {
            StreetType t;
            List<StreetSegment> s = new List<StreetSegment>();
            foreach(StreetConnector sc1 in connectors)
            {
                foreach(StreetConnector sc2 in connectors)
                {
                    if(sc1 != sc2 && sc1.FindNeighbours() != null && sc1.FindNeighbours().Contains(sc2))
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

        public static void AddTrafficLightPlans(TrafficLightPlan plan)
        {
            if(FindIntersectionPlan(plan.LightId) != null)
            {
                trafficlightPlans.Remove(FindIntersectionPlan(plan.LightId));  
            }
            trafficlightPlans.Add(plan);
        }

        private static TrafficLightPlan FindIntersectionPlan(int id)
        {
            return trafficlightPlans.Find(x => x.LightId == id);
        }

        /// <summary>
        /// Get List of Schedules from SS4 through the Datalinker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Datalinker_ss3_ReceiveMaintenanceSchedules(object sender, List<Schedule> e)
        {
            ReceiveMaintenanceSchedules(e);
        }


        /// <summary>
        /// Send Data to other subsystems
        /// </summary>
        public static void SendTrafficLichtPlans()
        {
            Master.DataLinker.SS3.SendTrafficLightPlans(trafficlightPlans);
        }
        public static void SendAllBaseRoute()
        {
			List<BaseRouteUpdate> routes = new List<BaseRouteUpdate>();

			foreach (BaseRoute path in paths) {
				routes.Add(new BaseRouteUpdate(path.ID, BaseRouteUpdate.UpdateType.New, path, null));
			}

			Master.DataLinker.SS3.SendBaseRouteUpdates(routes);
        }

        public static void SendRoadInstruction(RoadInstruction r)
        {
            Master.DataLinker.SS3.SendRoadInstruction(r);
        }

    }
}
