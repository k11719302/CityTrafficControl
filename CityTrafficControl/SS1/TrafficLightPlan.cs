using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master;

namespace CityTrafficControl.SS1
{
    class TrafficLightPlan
    {
        private int lightId;
        public int LightId { get { return lightId; } }

        //SS3 probably sends 2 arrays to the DataLinker: LightStates[] lightStates and double[] duration
        //but the DataLinker translates the information for the TrafficLightPlan to:
        private double redDuration; //seconds
        public double RedDuration { get { return redDuration; } set { redDuration = value; } }
        private double greenDuration;   //seconds
        public double GreenDuration { get { return greenDuration; } set { greenDuration = value; } }

        private DateTime timeStamp; //shows the time of the last update --> for calculating the time between two updates


        public TrafficLightPlan(int lightId, double redDuration, double greenDuration)
        {
            this.lightId = lightId;
            this.redDuration = redDuration;
            this.greenDuration = greenDuration;
            timeStamp = Master.SimulationManager.CurTickTime;
        }

        //this method updates the traffic lights state if needed
        public void Update()
        {
            TrafficLight light = TrafficControl.FindLight(lightId); //search for this light
            if (light != null)
            {
                TimeSpan timePassed = Master.SimulationManager.CurTickTime - timeStamp;
                if (light.State == LightStates.RED) //current state = red
                {
                    if (timePassed.TotalSeconds >= redDuration) //time for update
                    {
                        light.State = LightStates.GREEN;
                        timeStamp = Master.SimulationManager.CurTickTime; //update the timestamp too
                        //Console.WriteLine("light " + light.Id + " updated to " + light.State + " after " + timePassed.TotalSeconds + " seconds");
                    }
                }else if (light.State == LightStates.GREEN) //current state = green
                {
                    if (timePassed.TotalSeconds >= greenDuration)
                    {
                        light.State = LightStates.RED;
                        timeStamp = Master.SimulationManager.CurTickTime;
                        //Console.WriteLine("light " + light.Id + " updated to " + light.State + " after " + timePassed.TotalSeconds + " seconds");
                    }
                }
            }
        }
    }
}
