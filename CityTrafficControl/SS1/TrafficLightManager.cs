using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace CityTrafficControl.SS1
{
    class TrafficLightManager
    {
        private static List<TrafficLightPlan> trafficLightPlans = null;

        private static TrafficLightManager instance = null; ////using Singleton, because SS1 only needs one traffic light manager

        public TrafficLightManager() {
            trafficLightPlans = new List<TrafficLightPlan>();
        }

        public static TrafficLightManager GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrafficLightManager();
                }
                return instance;
            }
        }

        //this method is called by the SimulationManager in each tick
        //it then calls for each traffic light plan the update function which finally executes the update
        public static void UpdateTrafficLights()
        {
            foreach (TrafficLightPlan plan in trafficLightPlans)    //call for each existing TrafficLIghtpLan the update function
            {
                plan.Update();
            }
        }

        //checks the traffic light plan and adds it to the list, if there is no plan for this traffic light
        //or swaps it with the old plan of this traffic light
        public static void AddTrafficLightPlans (List<TrafficLightPlan> plans)
        {
            foreach (TrafficLightPlan plan in plans)
            {
                TrafficLightPlan p = FindTrafficLightPlan(plan.LightId);
                if(p == null) //if there is no plan for this traffic light
                {
                    trafficLightPlans.Add(plan);
                }
                else //if there is already a plan
                {
                    RemoveTrafficLightPlan(p);
                    trafficLightPlans.Add(plan);
                }
            }            
        }

        public static TrafficLightPlan FindTrafficLightPlan (int id)
        {
            return trafficLightPlans.Find(x => x.LightId == id);
        }

        public static bool RemoveTrafficLightPlan (TrafficLightPlan plan)
        {
            return trafficLightPlans.Remove(plan);
        }
    }
}
