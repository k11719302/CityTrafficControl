using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TrafficControlAndDetection
{
    class TrafficLightManager
    {
        private static List<CrossroadPlan> crossRoadPlans=null;

        private static System.Timers.Timer timer; //the timer, which is needed for the traffic light cycles
        public static System.Timers.Timer Timer { get => timer; }

        private static TrafficLightManager instance = null; ////using Singleton, because SS1 only needs one traffic light manager

        public TrafficLightManager() {
            crossRoadPlans = new List<CrossroadPlan>();
            SetTimer();
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

        public static void SetTimer()
        {
            timer = new System.Timers.Timer(1000); //timer with 1 second interval
            timer.Elapsed += OnTimedUpdate; //choose the elapsed event
            timer.AutoReset = true; //cyclic
            timer.Enabled = true;
        }

        //this method is called after each second with the help of the timers
        //it then calls for each traffic light plan the update function which finally executes the update
        private static void OnTimedUpdate(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("OnTimedUpdate at: " + e.SignalTime);
            foreach (CrossroadPlan crp in crossRoadPlans)
            {
                if (crp != null)
                {
                    foreach (TrafficLightPlan plan in crp.Plans)    //call for each existing TrafficLIghtpLan the update function
                    {
                        plan.Update();
                    }
                }

            }
        }

        //checks the cross road plan and adds it to the list, if there is no plan for this cross road
        //or swaps it with the old plan of this cross road
        public static void AddCrossRoadPlan (CrossroadPlan plan)
        {
            CrossroadPlan p = FindCrossRoadPlan(plan.CrossroadId);
            if (p == null) //if there is no plan for this cross road
            {
                crossRoadPlans.Add(plan);
            }
            else //if there is already a plan 
            {
                RemoveCrossRoadPlan(p);
                crossRoadPlans.Add(plan);
            }
            
        }

        public static CrossroadPlan FindCrossRoadPlan (int id)
        {
            return crossRoadPlans.Find(x => x.CrossroadId == id);
        }

        public static bool RemoveCrossRoadPlan (CrossroadPlan plan)
        {
            return crossRoadPlans.Remove(plan);
        }

        ////searches the traffic light with the given id and adapts its state
        //private static bool Adapttrafficlight(int id, LightStates state)
        //{
        //    TrafficLight light = TrafficControl.FindLight(id);
        //    if (light != null) //if this id exists, adapt the state of the light
        //    {
        //        light.State = state;
        //        return true;
        //    }
        //    return false;
        //}
    }
}
