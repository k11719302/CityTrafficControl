using CityTrafficControl.Master;
using CityTrafficControl.Master.StreetMap;
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
using System.Windows.Threading;

namespace CityTrafficControl {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		private Dispatcher dispatcher;


		public MainWindow() {
			InitializeComponent();
			dispatcher = Application.Current.Dispatcher;
		}

		private delegate void Invoker();


		public void PrintOutput(string str) {
			Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Invoker)delegate {
				Output_Tbx.Text = "[" + DateTime.Now.ToString("hh:mm:ss.fff") + "] " + str + "\n" + Output_Tbx.Text;
			});
		}
		public void PrintError(string str) {
			PrintOutput("ERROR: " + str);
		}

		private void Init_Btn_Click(object sender, RoutedEventArgs e) {
			/*switch(Master.Loader.Load()) {
				case Master.Loader.LoadingError.NoError: PrintOutput("Loading complete!"); break;
				case Master.Loader.LoadingError.AlreadyLoaded: PrintOutput("ERROR: Already loaded!"); break;
			}*/
			ReportManager.Init(this);
			StreetMapManager.Init();
			SimulationManager.Init();
		}

		private void Start_Btn_Click(object sender, RoutedEventArgs e) {
			//SimulationManager.Start();
			Task.Factory.StartNew(() => { SimulationManager.Start(); });
		}

		private void Stop_Btn_Click(object sender, RoutedEventArgs e) {
			//SimulationManager.Stop();
			Task.Factory.StartNew(() => { SimulationManager.Stop(); });
		}
	}
}
