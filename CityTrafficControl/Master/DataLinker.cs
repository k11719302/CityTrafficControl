using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTrafficControl.SS2.DataStructures;
using CityTrafficControl.Master.DataStructures;
using CityTrafficControl.SS1;
using CityTrafficControl.SS4;

namespace CityTrafficControl.Master {
	static class DataLinker {
		public static class SS1 {
			/// <summary>
			/// Static constructor/init
			/// </summary>
			static SS1() {

			}

			#region Receive

			#endregion

			#region Request

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
			public static event EventHandler<List<BaseRouteUpdate>> updateBaseRoutes;
			internal static void callUpdateBaseRoutes(List<BaseRouteUpdate> e) {
				updateBaseRoutes?.Invoke(null, e);
			}
			#endregion

			#region Request
			/// <summary>
			/// Sends a request to SS3 that it should itself make a base route update for SS2.
			/// If there were no updates, an empty list should be sent.
			/// </summary>
			public static void requestBaseRoutes() {
				SS3.callGetBaseRoutes(new EventArgs());
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
			public static event EventHandler getBaseRoutes;
			internal static void callGetBaseRoutes(EventArgs e) {
				getBaseRoutes?.Invoke(null, e);
			}
			#endregion

			#region Request
			
			#endregion
		}

		public static class SS4 {
			/// <summary>
			/// Static constructor/init
			/// </summary>
			static SS4() {

			}

			#region Receive
			public static void SendSchedules(List<Schedule> schedules) {
				// TODO
				throw new NotImplementedException();
			}

			public static void SendCurrentOperations(List<Schedule> currentOps) {
				// TODO
				throw new NotImplementedException();
			}
			#endregion

			#region Request
			public static List<Incident> requestIncidents() {
				// return SS1.CallGetIncidents(new EventArgs()); maybe
				throw new NotImplementedException();
			}
			#endregion
		}
	}
}
