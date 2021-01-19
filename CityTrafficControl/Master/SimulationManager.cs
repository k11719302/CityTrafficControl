using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master {
	/// <summary>
	/// Manages the simulation of the whole system.
	/// </summary>
	static class SimulationManager {
		/// <summary>
		/// Defines whether the system is in debug mode.
		/// </summary>
		public const bool DEBUG_MODE = true;

		private static bool isInitialized;
		private static bool isFirstTick;

		private static SimulationState state;

		private static DateTime lastTickTime;
		private static DateTime curTickTime;
		private static TimeSpan tickDuration;

		private static Random random;


		static SimulationManager() {
			isInitialized = false;
			isFirstTick = true;

			state = SimulationState.Stopped;

			random = new Random();
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
		/// Gets a Random instance that can be used for randomization.
		/// </summary>
		public static Random Random { get { return random; } }


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

			SS1.SimulationManager.Init(); ReportManager.PrintOutput("SimulationManager(SS1) initialized.");
			SS2.SimulationManager.Init(); ReportManager.PrintOutput("SimulationManager(SS2) initialized.");
			SS3.SimulationManager.Init(); ReportManager.PrintOutput("SimulationManager(SS3) initialized.");
			SS4.SimulationManager.Init(); ReportManager.PrintOutput("SimulationManager(SS4) initialized.");
		}

		/// <summary>
		/// Starts the simulation cycle.
		/// </summary>
		public static void Start() {
			if (state == SimulationState.Stopped) {
				ReportManager.PrintOutput("Simulation starting...");
				UpdateTimestamps(true);
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
				SimulateTick();
			}
			UpdateTimestamps();

			state = SimulationState.Stopped;
			ReportManager.PrintOutput("Simulation stopped.");
		}

		private static void SimulateTick() {
			SS1.SimulationManager.SimulateTick();
			SS2.SimulationManager.SimulateTick();
			SS3.SimulationManager.SimulateTick();
			SS4.SimulationManager.SimulateTick();

			UpdateTimestamps();
		}

		private static void UpdateTimestamps(bool fixStop = false) {
			if (isFirstTick) {
				isFirstTick = false;
				lastTickTime = DateTime.Now;
				curTickTime = lastTickTime;
				tickDuration = TimeSpan.Zero;
			}
			else {
				if (fixStop) {
					curTickTime = DateTime.Now;
					lastTickTime = curTickTime.Subtract(tickDuration);
				}
				else {
					lastTickTime = curTickTime;
					curTickTime = DateTime.Now;
					tickDuration = curTickTime.Subtract(lastTickTime);
				}
			}
		}


		/// <summary>
		/// The current state of the simulation.
		/// </summary>
		public enum SimulationState {
			Stopped, Starting, Running, Stopping
		}
	}
}
