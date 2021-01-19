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
            Master.DataLinker.SS1.ReceiveRoadCommand += DataLinker_SS1_ReceiveRoadCommand;
            Master.DataLinker.SS1.ReceiveTrafficLightPlans += DataLinker_SS1_ReceiveTrafficLightPlans;
        }

        /// <summary>
        /// Creates the first instance or always returns the singleton instance.
        /// </summary>
        public static TrafficControl GetInstance
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
            foreach (StreetConnector con in incident.Connectors) {
				if(con.Health >= 80)
                {
					con.Priority = 1;
				} else if(con.Health >= 60)
                {
					con.Priority = 2;
				} else if (con.Health >= 40)
                {
                    con.Priority = 3;
                } else if (con.Health >= 20)
                {
                    con.Priority = 4;
                } else
                {
                    con.Priority = 5;
                }
			}
            SendIncident(incident);
        }

        /// <summary>
        /// This method receives a new incident from the TrafficDetection and forwards it to the other subsystems.
        /// </summary>
        /// <param name="incident"></param>
        /// <returns></returns>
        public static void SendIncident(Incident incident)
        {
            Master.DataLinker.SS1.SendIncident(incident);
        }

        /// <summary>
        /// This method gets called by the DataLinker and receives a list of new TrafficLightPlans.
        /// It then forwards the plans to the TrafficLightManager.
        /// </summary>
        /// <param name="plans"></param>
        public static void ReceiveTrafficLightPlans (List<TrafficLightPlan> plans)
        {
            TrafficLightManager.AddTrafficLightPlans(plans);
        }

        //the DataLinker calls this method to forward a new road command from SS3
        //it returns true if the command is valid

        /// <summary>
        /// This method gets called by the DataLinker and receives a new RoadCommand from SS3.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool ReceiveRoadCommand(RoadInstruction command)
        {
            if (command != null)
            {
                StreetSegment road = roads.Find(x => x.ID == command.Id); //check, if there is a road with this id
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
        private static bool ExecuteRoadCommand(RoadInstruction command)
        {
            bool state = roads.Find(x => x.ID == command.Id).IsUsable; //store current state of the road
            bool success = false;

            if (command.Usable)    //state should be changed
            {
                success = AdaptRoadState(command.Id, command.Usable);
                if (!success) { return success; } //return, if adapting road state was not successfull
            }
            if (command.Speedlimit > 0)
            {
                success = AdaptSpeedLimit(command.Id, command.Speedlimit);
                if (command.Usable && !success) { AdaptRoadState(command.Id, state); } //if state has been adapted successfully, but speed limit not --> undo changes
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

        /// <summary>
        /// Adds a new light to the list lights.
        /// </summary>
        /// <param name="light">The light which needs to be added.</param>
        public static void AddLight(TrafficLight light)
        {
            lights.Add(light);
        }

        /// <summary>
        /// Removes a light from the list lights. Returns true in case of a success.
        /// </summary>
        /// <param name="light">The light which needs to be removed.</param>
        /// <returns></returns>
        public static bool RemoveLight(TrafficLight light)
        {
            return lights.Remove(light);
        }

        /// <summary>
        /// Finds a light in the list lights. Returns the found light or false if not found.
        /// </summary>
        /// <param name="id">The ID of the light which needs to be found.</param>
        /// <returns></returns>
        public static TrafficLight FindLight(int id)
        {
            return lights.Find(x => x.Id == id);
        }

        /// <summary>
        /// Adds a new StreetSegment to the list of roads.
        /// </summary>
        /// <param name="road">The StreetSegment which needs to be added.</param>
        public static void AddRoadSegment(StreetSegment road)
        {
            roads.Add(road);
        }

        /// <summary>
        /// Removes a StreetSegment from the list roads. Returns true in case of a success.
        /// </summary>
        /// <param name="road">The StreetSegment which needs to be removed.</param>
        /// <returns></returns>
        public static bool RemoveRoadSegment(StreetSegment road)
        {
            return roads.Remove(road);
        }

        /// <summary>
        /// Finds a StreetSegment in the list roads. Returns the found object or false if not found.
        /// </summary>
        /// <param name="id">The StreetSegment which needs to be found.</param>
        /// <returns></returns>
        public static StreetSegment FindRoadSegment(int id)
        {
            return roads.Find(x => x.ID == id);
        }

        private void DataLinker_SS1_ReceiveTrafficLightPlans(object sender, List<TrafficLightPlan> e)
        {
            ReceiveTrafficLightPlans(e);
        }
        private void DataLinker_SS1_ReceiveRoadCommand(object sender, RoadInstruction e)
        {
            ReceiveRoadCommand(e);
        }
    }
}
