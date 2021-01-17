using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master {
	static class SimulationManager {
		public const bool DEBUG_MODE = true;

		private static bool isInitialized;
		private static bool isFirstTick;
		
		private static SimulationState state;

		private static DateTime lastTickTime;
		private static DateTime curTickTime;
		private static TimeSpan tickDuration;


		static SimulationManager() {
			isInitialized = false;
			isFirstTick = true;

			state = SimulationState.Stopped;
		}


		/// <summary>
		/// Gets the current simulation state.
		/// </summary>
		public static SimulationState State { get { return state; } }

		/// <summary>
		/// Gets the time of the last tick.
		/// </summary>
		public static DateTime LastTickTime { get { return lastTickTime; } }
		/// <summary>
		/// Gets the time of the current tick.
		/// </summary>
		public static DateTime CurTickTime { get { return curTickTime; } }
		/// <summary>
		/// Gets the time span of the current tick.
		/// </summary>
		public static TimeSpan TickDuration { get { return tickDuration; } }


		/// <summary>
		/// Initializes the SimulationManager.
		/// </summary>
		public static void Init() {
			if (isInitialized) {
				ReportManager.PrintError("SimulationManager(Master) already initialized!");
				return;
			}

			isInitialized = true;
			ReportManager.PrintOutput("SimulationManager(Master) initialized.");

			SS1.SimulationManager.Init();
			SS2.SimulationManager.Init();
			SS3.SimulationManager.Init();
			SS4.SimulationManager.Init();
		}

		/// <summary>
		/// Starts the simulation cycle.
		/// </summary>
		public static void Start() {
			if (state == SimulationState.Stopped) {
				ReportManager.PrintOutput("Simulation starting...");
				state = SimulationState.Starting;
				SimulationCycle();
			}
			else {
				ReportManager.PrintError("Simulation already running!");
			}
		}

		/// <summary>
		/// Stops the simulation cycle.
		/// </summary>
		public static void Stop() {
			if (state == SimulationState.Running) {
				ReportManager.PrintOutput("Simulation stopping...");
				state = SimulationState.Stopping;
			}
			else {
				ReportManager.PrintError("Simulation not running!");
			}
		}

		/// <summary>
		/// Advances a single tick in the simulation.
		/// </summary>
		public static void SimulateSingleTick() {
			if (state == SimulationState.Stopped) {
				SimulateTick();
			}
			else {
				ReportManager.PrintError("Cannot simulate single tick, as simulation is not stopped!");
			}
		}


		private static void SimulationCycle() {
			state = SimulationState.Running;
			ReportManager.PrintOutput("Simulation started.");
			while (state == SimulationState.Running) {
				// simulate ticks
			}

			state = SimulationState.Stopped;
			ReportManager.PrintOutput("Simulation stopped.");
		}

		private static void SimulateTick() {
			UpdateTimestamps();

			SS1.SimulationManager.SimulateTick();
			SS2.SimulationManager.SimulateTick();
			SS3.SimulationManager.SimulateTick();
			SS4.SimulationManager.SimulateTick();
		}

		private static void UpdateTimestamps() {
			if (isFirstTick) {
				isFirstTick = false;
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
