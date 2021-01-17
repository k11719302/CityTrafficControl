using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.SS2.DataStructures;
using CityTrafficControl.Master.DataStructures;
using CityTrafficControl.SS1;
using CityTrafficControl.SS4;
using CityTrafficControl.SS3;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.Master {
	static class DataLinker {
		public static class Master {
			/// <summary>
			/// Static constructor/init
			/// </summary>
			static Master() {

			}

			#region Receive

			#endregion

			#region Request/Send
			public static void SendNaturalDesasterInfo(List<StreetConnector> e) {
				SS1.CallDetectNaturalDisaster(e);
			}
			#endregion
		}
		public static class SS1 {
			/// <summary>
			/// Static constructor/init
			/// </summary>
			static SS1() {

			}

			#region Receive
			public static event EventHandler<List<StreetConnector>> DetectNaturalDisaster;
			internal static void CallDetectNaturalDisaster(List<StreetConnector> e) {
				DetectNaturalDisaster?.Invoke(null, e);
			}

			public static event EventHandler<List<StreetConnector>> DetectAccident;
			internal static void CallDetectAccident(List<StreetConnector> e)
            {
				DetectAccident?.Invoke(null, e);
            }

			public static event EventHandler<List<TrafficLightPlan>> ReceiveTrafficLightPlans;
			internal static void CallReceiveTrafficLightPlans(List<TrafficLightPlan> e)
            {
				ReceiveTrafficLightPlans?.Invoke(null, e);
            }

			public static event EventHandler<RoadInstruction> ReceiveRoadCommand;
			internal static void CallReceiveRoadCommand (RoadInstruction e)
            {
				ReceiveRoadCommand?.Invoke(null, e);
            }
			#endregion

			#region Request/Send
			public static void SendIncident(Incident e)
			{
				//SS3.CallReceiveIncident(e);
				//SS4.CallReceiveIncident(e);
			}
			#endregion
		}

		public static class SS2 {
			/// <summary>
			/// Static constructor/init
			/// </summary>
			static SS2() {

			}

			#region Receive
			/// <summary>
			/// Takes a list of <code>BaseRouteUpdate</code>s and performs the update.
			/// </summary>
			public static event EventHandler<List<BaseRouteUpdate>> UpdateBaseRoutes;
			internal static void CallUpdateBaseRoutes(List<BaseRouteUpdate> e) {
				UpdateBaseRoutes?.Invoke(null, e);
			}
			#endregion

			#region Request/Send
			/// <summary>
			/// Sends a request to SS3 that it should itself make a base route update for SS2.
			/// If there were no updates, an empty list should be sent.
			/// </summary>
			public static void RequestBaseRoutes() {
				SS3.CallGetBaseRoutes(new EventArgs());
			}
			#endregion
		}

		public static class SS3 {
			/// <summary>
			/// Static constructor/init
			/// </summary>
			static SS3() {

			}

			#region Receive
			public static event EventHandler GetBaseRoutes;
			internal static void CallGetBaseRoutes(EventArgs e) {
				GetBaseRoutes?.Invoke(null, e);
			}

			public static event EventHandler<List<Schedule>> ReceiveMaintenanceSchedules;
			internal static void CallReceiveMaintenanceSchedules(List<Schedule> e) {
				ReceiveMaintenanceSchedules?.Invoke(null, e);
			}
			#endregion

			#region Request/Send
			public static void SendBaseRouteUpdates(List<BaseRouteUpdate> e) {
				SS2.CallUpdateBaseRoutes(e);
			}
			#endregion
		}

		public static class SS4 {
			/// <summary>
			/// Static constructor/init
			/// </summary>
			static SS4() {

			}

			#region Receive
			public static List<Incident> RequestIncidents() {
				// return SS1.CallGetIncidents(new EventArgs()); maybe
				throw new NotImplementedException();
			}
			#endregion

			#region Request/Send
			public static void SendSchedules(List<Schedule> e) {
				SS3.CallReceiveMaintenanceSchedules(e);
			}

			public static void SendCurrentOperations(List<Schedule> e) {
				// TODO
				throw new NotImplementedException();
			}
			#endregion
		}
	}
}
