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
		private VirtualConsole console;
		private bool init;


		public MainWindow() {
			InitializeComponent();
			dispatcher = Application.Current.Dispatcher;
			console = new VirtualConsole(150);
			init = false;
		}

		private delegate void Invoker();


		public void PrintOutput(string str) {
			Dispatcher.BeginInvoke(DispatcherPriority.Render, (Invoker)delegate {
				console.Print(string.Format("[{0}] {1}", DateTime.Now.ToString("hh:mm:ss.fff"), str));
				Output_Tbx.Text = console.ToString();
				Output_Tbx.ScrollToEnd();
			});
		}
		public void PrintError(string str) {
			Dispatcher.BeginInvoke(DispatcherPriority.Render, (Invoker)delegate {
				console.Print(string.Format("[{0}] ERROR: {1}", DateTime.Now.ToString("hh:mm:ss.fff"), str));
				Output_Tbx.Text = console.ToString();
				Output_Tbx.ScrollToEnd();
			});
		}
		public void PrintDebug(string str) {
			Dispatcher.BeginInvoke(DispatcherPriority.Render, (Invoker)delegate {
				console.Print(string.Format("[{0}] DEBUG: {1}", DateTime.Now.ToString("hh:mm:ss.fff"), str));
				Output_Tbx.Text = console.ToString();
				Output_Tbx.ScrollToEnd();
			});
		}

		private void Init_Btn_Click(object sender, RoutedEventArgs e) {
			Task.Factory.StartNew(() => {
				ReportManager.Init(this);
				StreetMapManager.Init();
				SimulationManager.Init();
			});
			Stopped_Grid.Visibility = Visibility.Visible;
			init = true;
		}

		private void Start_Btn_Click(object sender, RoutedEventArgs e) {
			if (!init) return;
			Task.Factory.StartNew(() => { SimulationManager.Start(); });
			Running_Grid.Visibility = Visibility.Visible;
		}

		private void Stop_Btn_Click(object sender, RoutedEventArgs e) {
			if (!init) return;
			Task.Factory.StartNew(() => { SimulationManager.Stop(); });
			Running_Grid.Visibility = Visibility.Hidden;
		}
	}
}
