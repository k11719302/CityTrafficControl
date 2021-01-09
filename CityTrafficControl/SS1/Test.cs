using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TrafficControlAndDetection
{
    class Test
    {

        public static void Main()
        {

            Console.WriteLine("\nPress any key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);

            //example of receiving and executing road commands and crossroad plans
            TrafficLight light1 = new TrafficLight(1, null, LightStates.RED, 1);
            TrafficLight light2 = new TrafficLight(2, null, LightStates.RED, 1);
            TrafficLight light3 = new TrafficLight(3, null, LightStates.GREEN, 1);
            TrafficLight light4 = new TrafficLight(4, null, LightStates.RED, 1);
            RoadSegment road1 = new RoadSegment(RoadTypes.EXPRESSWAY, 1, null, null, RoadStates.FREE, 2, 50, 1);
            RoadSegment road2 = new RoadSegment(RoadTypes.EXPRESSWAY, 2, null, null, RoadStates.FREE, 2, 60, 1);
            RoadSegment road3 = new RoadSegment(RoadTypes.EXPRESSWAY, 3, null, null, RoadStates.FREE, 2, 50, 1);
            RoadSegment road4 = new RoadSegment(RoadTypes.EXPRESSWAY, 4, null, null, RoadStates.FREE, 2, 60, 1);
            Crossroad cr1 = new Crossroad(1);
            cr1.addLight(light1);
            cr1.addLight(light2);
            cr1.addLight(light3);
            cr1.addLight(light4);
            cr1.addRoadSegment(road1);
            cr1.addRoadSegment(road2);
            cr1.addRoadSegment(road3);
            cr1.addRoadSegment(road4);

            TrafficLight light5 = new TrafficLight(5, null, LightStates.RED, 2);
            TrafficLight light6 = new TrafficLight(6, null, LightStates.RED, 2);
            TrafficLight light7 = new TrafficLight(7, null, LightStates.GREEN, 2);
            TrafficLight light8 = new TrafficLight(8, null, LightStates.RED, 2);
            RoadSegment road5 = new RoadSegment(RoadTypes.EXPRESSWAY, 5, null, null, RoadStates.FREE, 2, 50, 2);
            RoadSegment road6 = new RoadSegment(RoadTypes.EXPRESSWAY, 6, null, null, RoadStates.FREE, 2, 60, 2);
            RoadSegment road7 = new RoadSegment(RoadTypes.EXPRESSWAY, 7, null, null, RoadStates.FREE, 2, 50, 2);
            RoadSegment road8 = new RoadSegment(RoadTypes.EXPRESSWAY, 8, null, null, RoadStates.FREE, 2, 60, 2);
            Crossroad cr2 = new Crossroad(2);
            cr2.addLight(light5);
            cr2.addLight(light6);
            cr2.addLight(light7);
            cr2.addLight(light8);
            cr2.addRoadSegment(road5);
            cr2.addRoadSegment(road6);
            cr2.addRoadSegment(road7);
            cr2.addRoadSegment(road8);

            TrafficControl controler = TrafficControl.GetInstance;
            TrafficLightManager lightManager = TrafficLightManager.GetInstance;
            TrafficControl.AddLight(light1);
            TrafficControl.AddLight(light2);
            TrafficControl.AddLight(light3);
            TrafficControl.AddLight(light4);
            TrafficControl.AddRoadSegment(road1);
            TrafficControl.AddRoadSegment(road2);
            TrafficControl.AddRoadSegment(road3);
            TrafficControl.AddRoadSegment(road4);
            TrafficControl.AddLight(light5);
            TrafficControl.AddLight(light6);
            TrafficControl.AddLight(light7);
            TrafficControl.AddLight(light8);
            TrafficControl.AddRoadSegment(road5);
            TrafficControl.AddRoadSegment(road6);
            TrafficControl.AddRoadSegment(road7);
            TrafficControl.AddRoadSegment(road8);
            TrafficControl.AddCrossRoad(cr1);
            TrafficControl.AddCrossRoad(cr2);

            //TrafficControl.PrintRoads();
            //TrafficControl.PrintLights();
            TrafficControl.PrintCrossroads();

            RoadCommand roadCommand = new RoadCommand(2, RoadStates.BLOCKED);
            RoadCommand roadC2 = new RoadCommand(5, RoadStates.BLOCKED, 80);
            RoadCommand roadC3 = new RoadCommand(7, false, 70);
            TrafficControl.ReceiveRoadCommand(roadCommand);
            TrafficControl.ReceiveRoadCommand(roadC2);
            TrafficControl.ReceiveRoadCommand(roadC3);
            TrafficControl.ReceiveRoadCommand(new RoadCommand(0, RoadStates.FREE));
            TrafficControl.PrintCrossroads();

            TrafficLightPlan tlplan1 = new TrafficLightPlan(1, 4, 2);
            TrafficLightPlan tlplan2 = new TrafficLightPlan(2, 5, 2);
            TrafficLightPlan tlplan3 = new TrafficLightPlan(3, 4, 3);
            TrafficLightPlan tlplan4 = new TrafficLightPlan(4, 3, 1);
            List<TrafficLightPlan> plans = new List<TrafficLightPlan>();
            plans.Add(tlplan1);
            plans.Add(tlplan2);
            plans.Add(tlplan3);
            plans.Add(tlplan4);
            CrossroadPlan plan = new CrossroadPlan(1,plans);
            TrafficControl.ReceiveCrossRoadPlan(plan);
            TrafficControl.ReceiveCrossRoadPlan(new CrossroadPlan(4, null));
            Console.ReadKey();
            TrafficLightManager.Timer.Stop();
            TrafficLightManager.Timer.Dispose();
            Console.WriteLine("Terminating the application...");
        }

    }
}
