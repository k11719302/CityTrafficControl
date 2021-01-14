using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master {
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
			mainWindow.PrintOutput(str);
		}

		/// <summary>
		/// Prints an error string to the output in the MainWindow.
		/// </summary>
		/// <param name="str">The error string to print</param>
		public static void PrintError(string str) {
			mainWindow.PrintError(str);
		}
	}
}
