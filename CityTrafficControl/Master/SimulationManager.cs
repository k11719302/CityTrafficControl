using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master {
	static class SimulationManager {
		private static MainWindow mainWindow;

		private static bool isInitialized;
		private static bool firstTick;

		private static SimulationState state;

		private static DateTime lastTickTime;
		private static DateTime curTickTime;
		private static TimeSpan tickDuration;


		static SimulationManager() {
			isInitialized = false;
			firstTick = true;

			state = SimulationState.Stopped;
		}


		public static SimulationState State { get { return state; } }

		public static DateTime LastTickTime { get { return lastTickTime; } }
		public static DateTime CurTickTime { get { return curTickTime; } }
		public static TimeSpan TickDuration { get { return tickDuration; } }


		public static void Init(MainWindow win) {
			if (isInitialized) {
				PrintError("SimulationManager(Master) already initialized!");
				return;
			}

			isInitialized = true;
			mainWindow = win;
			PrintOutput("SimulationManager(Master) initialized.");

			SS1.SimulationManager.Init();
			SS2.SimulationManager.Init();
			SS3.SimulationManager.Init();
			SS4.SimulationManager.Init();
		}

		public static void PrintOutput(string str) {
			mainWindow.PrintOutput(str);
		}

		public static void PrintError(string str) {
			mainWindow.PrintError(str);
		}

		public static void Start() {
			if (state == SimulationState.Stopped) {
				PrintOutput("Simulation starting...");
				state = SimulationState.Starting;
				SimulationCycle();
			}
			else {
				PrintError("Simulation already running!");
			}
		}

		public static void Stop() {
			if (state == SimulationState.Running) {
				PrintOutput("Simulation stopping...");
				state = SimulationState.Stopping;
			}
			else {
				PrintError("Simulation not running!");
			}
		}

		public static void SimulateSingleTick() {
			if (state == SimulationState.Stopped) {
				SimulateTick();
			}
			else {
				PrintError("Cannot simulate single tick, as simulation is not stopped!");
			}
		}


		private static void SimulationCycle() {
			state = SimulationState.Running;
			PrintOutput("Simulation started.");
			while (state == SimulationState.Running) {
				// simulate ticks
			}

			state = SimulationState.Stopped;
			PrintOutput("Simulation stopped.");
		}

		private static void SimulateTick() {
			UpdateTimestamps();

			SS1.SimulationManager.SimulateTick();
			SS2.SimulationManager.SimulateTick();
			SS3.SimulationManager.SimulateTick();
			SS4.SimulationManager.SimulateTick();
		}

		private static void UpdateTimestamps() {
			if (firstTick) {
				firstTick = false;
				lastTickTime = DateTime.Now;
				curTickTime = lastTickTime;
				tickDuration = TimeSpan.Zero;
			}
			else {
				lastTickTime = curTickTime;
				curTickTime = DateTime.Now;
				tickDuration = curTickTime.Subtract(lastTickTime);
			}
		}


		public enum SimulationState {
			Stopped, Starting, Running, Stopping
		}
	}
}
