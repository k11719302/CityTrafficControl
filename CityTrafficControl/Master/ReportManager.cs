using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master {
	/// <summary>
	/// Is used to report messages to the MainWindow.
	/// </summary>
	public static class ReportManager {
		private static MainWindow mainWindow;

		private static bool isInitialized;


		static ReportManager() {
			isInitialized = false;
		}


		/// <summary>
		/// Initializes the ReportManager.
		/// </summary>
		/// <param name="win">The reference to the MainWindow</param>
		public static void Init(MainWindow win) {
			if (isInitialized) {
				PrintError("ReportManager already initialized!");
				return;
			}

			isInitialized = true;
			mainWindow = win;
			PrintOutput("ReportManager initialized.");
		}

		/// <summary>
		/// Prints a string to the output in the MainWindow.
		/// </summary>
		/// <param name="str">The string to print</param>
		public static void PrintOutput(string str) {
			if (isInitialized) {
				mainWindow.PrintOutput(str);
			}
		}

		/// <summary>
		/// Prints an error string to the output in the MainWindow.
		/// </summary>
		/// <param name="str">The error string to print</param>
		public static void PrintError(string str) {
			if (isInitialized) {
				mainWindow.PrintError(str);
			}
		}

		/// <summary>
		/// Prints a debug string to the output in the MainWindow if DEBUG_MODE is on.
		/// </summary>
		/// <param name="str">The debug string to print</param>
		public static void PrintDebug(string str) {
			if (isInitialized && SimulationManager.DEBUG_MODE) {
				mainWindow.PrintDebug(str);
			}
		}
	}
}
