using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CityTrafficControl {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void PrintOutput(string str) {
			Output_Tbx.Text = DateTime.Now.ToString("hh:mm:ss") + ": " + str + "\n" + Output_Tbx.Text;
		}
		private void PrintError(string str) {
			PrintOutput("ERROR: " + str);
		}

		private void Load_Btn_Click(object sender, RoutedEventArgs e) {
			switch(Master.Loader.Load()) {
				case Master.Loader.LoadingError.NoError: PrintOutput("Loading complete!"); break;
				case Master.Loader.LoadingError.AlreadyLoaded: PrintOutput("ERROR: Already loaded!"); break;
			}
		}
	}
}
