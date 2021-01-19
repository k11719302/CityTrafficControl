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
        /// <summary>
        /// Creates the first instance or always returns the singleton instance.
        /// </summary>
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


        /// <summary>
        /// This method is called by the SimulationManager in each tick.
        ///  It then calls for each traffic light plan the update function which finally executes the update.        
        /// </summary>
        public static void UpdateTrafficLights()
        {
            foreach (TrafficLightPlan plan in trafficLightPlans)    //call for each existing TrafficLIghtpLan the update function
            {
                plan.Update();
            }
        }
        /// <summary>
        /// Checks the traffic light plan and adds it to the list, if there is no plan for this traffic light
        /// or swaps it with the old plan of this traffic light.
        /// </summary>
        /// <param name="plans"></param>
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

        /// <summary>
        /// Finds the TrafficLightPlan with the chosen id in the list of plans. Returns the found object or false if not found.
        /// </summary>
        /// <param name="id">The ID of the TrafficLightPlan which needs to be found.</param>
        /// <returns></returns>
        public static TrafficLightPlan FindTrafficLightPlan (int id)
        {
            return trafficLightPlans.Find(x => x.LightId == id);
        }
        /// <summary>
        /// Removes the TrafficLightPlan from the list of plans. Returns true in case of success.
        /// </summary>
        /// <param name="plan">The TrafficLightPlan which needs to be removed.</param>
        /// <returns></returns>
        public static bool RemoveTrafficLightPlan (TrafficLightPlan plan)
        {
            return trafficLightPlans.Remove(plan);
        }
    }
}
