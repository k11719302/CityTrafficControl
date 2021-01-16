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

        //TrafficControl is the core of SS1 and should contain a list of all lights, all road segments
        private static List<TrafficLight> lights = null;

        private static List<StreetSegment> roads = null;

        private TrafficControl() {
            lights = new List<TrafficLight>();
            roads = new List<StreetSegment>();
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

        //gets called by the TrafficDetection and receives a new incident
        //adapts the priority of all the involved StreetConnectors
        //calls the SendIncident method
        public static void IncidentDetected (Incident incident)
        {
            double priority = CalculateIncidentPriority(incident.Type, incident.InvolvedObjects, incident.RoadDamage);
            foreach (StreetConnector street in incident.Connectors)
            {
                street.Priority = priority;
            }
            SendIncident(incident);
        }

        /// <summary>
        /// This method receives a new incident from the TrafficDetection and forwards it to the other subsystems.
        /// </summary>
        /// <param name="incident"></param>
        /// <returns></returns>
        public static Incident SendIncident(Incident incident)
        {
            throw new NotImplementedException();
        }

        //calculates the priority, which later informs SS4 about the importance of the incident
        private static double CalculateIncidentPriority(IncidentType type, int involvedObjects, bool roadDamage)
        {
            throw new NotImplementedException();
        }

        //the DataLinker calls this method to forward a list of new TrafficLightPlans
        //it returns true if the plan has been forwarded to the traffic light manager
        public static void ReceiveTrafficLightPlans (List<TrafficLightPlan> plans)
        {
            TrafficLightManager.AddTrafficLightPlans(plans);
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
    }
}
