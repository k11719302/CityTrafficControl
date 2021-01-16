using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.SS3;
using CityTrafficControl.Master.StreetMap;


namespace CityTrafficControl.SS1
{
    class TrafficControl
    {
        private static TrafficControl instance = null; //using Singleton, because SS1 only needs one traffic controler

        //TrafficControl is the core of SS1 and should contain a list of all lights, all road segments and all crossroads
        private static List<TrafficLight> lights = null;

        private static List<StreetSegment> roads = null;

        private static List<Crossroad> crossRoads = null;

        private TrafficControl() {
            lights = new List<TrafficLight>();
            roads = new List<StreetSegment>();
            crossRoads = new List<Crossroad>();
        }

        public static TrafficControl GetInstance //creates the first instance or always returns the singleton instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrafficControl();
                }
                return instance;
            }

        }

        //gets called by TrafficDetection
        //forwards information to the DataLinker
        public static void IncidentDetected (Incident incident)
        {
            //TODO call DataLinker, forward info about incident to SS4 and SS3
        }

        //the DataLinker calls this method to forward a new cross road plan
        //it returns true if the cross road Id is valid and the plan has been forwarded to the traffic light manager
        public static bool ReceiveCrossRoadPlan (CrossroadPlan plan)
        {
            Crossroad cr = FindCrossRoad(plan.CrossroadId);
            if (cr != null) //if this cross road exists
            {
                TrafficLightManager.AddCrossRoadPlan(plan);
                return true;
            }
            return false;
        }

        //the DataLinker calls this method to forward a new road command from SS3
        //it returns true if the command is valid
        public static bool ReceiveRoadCommand(RoadCommand command)
        {
            if (command != null)
            {
                StreetSegment road = roads.Find(x => x.ID == command.RoadId); //check, if there is a road with this id
                if(road!=null) //road should be valid
                {
                    ExecuteRoadCommand(command);
                    return true;
                }
            }
            return false;
        }

        //this method executes the road command, i.e. adapts states and speed limits
        //it returns true, if the execution has been successful
        private static bool ExecuteRoadCommand(RoadCommand command)
        {
            bool state = roads.Find(x => x.ID == command.RoadId).IsUsable; //store current state of the road
            bool success = false;

            if (command.State)    //state should be changed
            {
                success = AdaptRoadState(command.RoadId, command.State);
                if (!success) { return success; } //return, if adapting road state was not successfull
            }
            if (command.SpeedLimit > 0)
            {
                success = AdaptSpeedLimit(command.RoadId, command.SpeedLimit);
                if (command.State && !success) { AdaptRoadState(command.RoadId, state); } //if state has been adapted successfully, but speed limit not --> undo changes
            }
            return success;
        }

        //adapts the state of the chosen road
        private static bool AdaptRoadState (int roadId, bool state)
        {
            StreetSegment road = roads.Find(x => x.ID == roadId);
            if (road != null)
            {
                road.IsUsable = state;
                return true;
            }
            return false;
        }

        //adapts the speed limit of the chosen road
        private static bool AdaptSpeedLimit (int roadId, double limit)
        {
            StreetSegment road = roads.Find(x => x.ID == roadId);
            if (road != null)
            {
                road.SpeedLimit = limit;
                return true;
            }
            return false;
        }
        public static void AddLight(TrafficLight light)
        {
            lights.Add(light);
        }

        public static bool RemoveLight(TrafficLight light)
        {
            return lights.Remove(light);
        }

        public static TrafficLight FindLight(int id)
        {
            return lights.Find(x => x.Id == id);
        }

        public static void AddRoadSegment(StreetSegment road)
        {
            roads.Add(road);
        }

        public static bool RemoveRoadSegment(StreetSegment road)
        {
            return roads.Remove(road);
        }

        public static StreetSegment FindRoadSegment(int id)
        {
            return roads.Find(x => x.ID == id);
        }

        public static void AddCrossRoad(Crossroad crossRoad)
        {
            crossRoads.Add(crossRoad);
        }

        public static bool RemoveCrossRoad(Crossroad crossRoad)
        {
            return crossRoads.Remove(crossRoad);
        }

        public static Crossroad FindCrossRoad(int id)
        {
            return crossRoads.Find(x => x.Id == id);
        }

        public static void PrintLights()
        {
            Console.WriteLine("lights: ");
            foreach (TrafficLight l in lights)
            {

                if (l != null)
                {
                    l.PrintLight();
                }

            }
        }
        public static void PrintRoads()
        {
            Console.WriteLine("roads: ");
            foreach (StreetSegment r in roads)
            {
                if (r != null)
                {
                    //r.PrintRoad();
                }
            }
        }
        public static void PrintCrossroads()
        {
            Console.WriteLine("crossroads: ");
            foreach (Crossroad cr in crossRoads)
            {
                if (cr != null)
                {
                    cr.PrintCrossroad();
                }
            }
        }
    }
}
