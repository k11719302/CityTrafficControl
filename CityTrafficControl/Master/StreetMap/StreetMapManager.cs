using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
	/// <summary>
	/// Manages all interactions with the StreetMap.
	/// </summary>
	static class StreetMapManager {
		private static bool isInitialized;

		private static SortedDictionary<int, StreetConnector> connectors;
		private static SortedDictionary<int, StreetHub> hubs;
		private static SortedDictionary<int, StreetSegment> segments;
		private static SortedDictionary<int, Building> buildings;
		private static SortedDictionary<int, PublicTransportStation> stations;


		static StreetMapManager() {
			isInitialized = false;
			connectors = new SortedDictionary<int, StreetConnector>();
			hubs = new SortedDictionary<int, StreetHub>();
			segments = new SortedDictionary<int, StreetSegment>();
			buildings = new SortedDictionary<int, Building>();
			stations = new SortedDictionary<int, PublicTransportStation>();
		}


		/// <summary>
		/// Initializes the StreetMapManager.
		/// </summary>
		public static void Init() {
			if (isInitialized) {
				ReportManager.PrintError("StreetMapManager already initialized!");
				return;
			}

			isInitialized = true;
			InitStaticMap();
			ReportManager.PrintOutput("StreetMapManager initialized.");
		}

		/// <summary>
		/// Generates a natural disaster, damages the affected StreetConnectors and returns them.
		/// </summary>
		/// <param name="center">The center of the natural disaster where the max damage is dealt</param>
		/// <param name="radius">The radius of effect of this natural disaster</param>
		/// <param name="strength">The amount of damage that this natural disaster deals in the center</param>
		/// <returns>A list of all affected StreetConnectors</returns>
		public static List<StreetConnector> CreateNaturalDisaster(Coordinate center, double radius, double strength) {
			List<StreetConnector> affected = new List<StreetConnector>();
			double distance;

			foreach (StreetConnector connector in connectors.Values) {
				distance = Coordinate.GetDistance(center, connector.Coordinate);
				if (distance > radius) continue;
				connector.Health -= (radius - distance) * strength;
				affected.Add(connector);
			}

			return affected;
		}


		private static void InitStaticMap() {
			//InitSmallStaticMap();
			InitStaticCityMap();
		}
		private static void InitSmallStaticMap() {
			StreetConnector c1, c2, c3, c4;
			StreetHub h1;

			// # StreetConnector
			// - StreetSegment
			// ~ StreetHub
			// ^ Building

			/*   ^   ^         ^
			 * 	 #---#~~~~~#---#
			 * 	 -      ~      -
			 * 	 -   ^  ~      -
			 *	 #---#~~~~~#---#^
			 */

			Save(c1 = new StreetConnector(0, 0));
			Save(c2 = new StreetConnector(400, 0));
			Save(c3 = new StreetConnector(0, 300));
			Save(c4 = new StreetConnector(400, 300));
			Save(new Building(c1));
			Save(new Building(c2));
			Save(new Building(c4));
			Save(new StreetSegment(c1, c2));
			Save(new StreetSegment(c1, c3));
			Save(new StreetSegment(c3, c4));
			Save(c1 = new StreetConnector(1000, 0));
			Save(c3 = new StreetConnector(1000, 300));
			Save(h1 = new StreetHub());
			h1.Connect(c1);
			h1.Connect(c2);
			h1.Connect(c3);
			h1.Connect(c4);
			Save(c2 = new StreetConnector(1400, 0));
			Save(c4 = new StreetConnector(1400, 300));
			Save(new Building(c2));
			Save(new Building(c4));
			Save(new StreetSegment(c1, c2));
			Save(new StreetSegment(c2, c4));
			Save(new StreetSegment(c3, c4));
		}
		private static void InitStaticCityMap() {
			// see excel file (table 1) for graphical representation

			StreetConnector c1, c2, c3, c4, c5, c6, c7, c8;
			StreetHub h1, h2, h3, h4;

			// residential area 1 (left upper)
			Save(c1 = new StreetConnector(20, 20));
			Save(new Building(c1));
			Save(h1 = new StreetHub());
			h1.Connect(c1);
			Save(c2 = new StreetConnector(60, 20));
			Save(new Building(c2));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(100, 20));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(c4 = new StreetConnector(140, 20));
			Save(new Building(c4));
			Save(new StreetSegment(c3, c4));
			Save(c5 = new StreetConnector(180, 20));
			Save(new Building(c5));
			Save(new StreetSegment(c4, c5));
			Save(h2 = new StreetHub());
			h2.Connect(c5);

			// residential area 2 (left upper)
			Save(c1 = new StreetConnector(20, 60));
			Save(new Building(c1));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(60, 60));
			Save(new Building(c2));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(100, 60));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(c4 = new StreetConnector(140, 60));
			Save(new Building(c4));
			Save(new StreetSegment(c3, c4));
			Save(c5 = new StreetConnector(180, 60));
			Save(new Building(c5));
			Save(new StreetSegment(c4, c5));
			h2.Connect(c5);

			// residential area 3 (left upper)
			Save(c1 = new StreetConnector(20, 100));
			Save(new Building(c1));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(60, 100));
			Save(new Building(c2));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(100, 100));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(c4 = new StreetConnector(140, 100));
			Save(new Building(c4));
			Save(new StreetSegment(c3, c4));
			Save(c5 = new StreetConnector(180, 100));
			Save(new Building(c5));
			Save(new StreetSegment(c4, c5));
			h2.Connect(c5);

			// point below residential area in mid
			Save(c1 = new StreetConnector(200, 120));
			h2.Connect(c1);
			Save(h1 = new StreetHub());
			h1.Connect(c1);

			// long streets on top with triangle at right
			Save(c1 = new StreetConnector(210, 20));
			h2.Connect(c1);
			Save(c2 = new StreetConnector(270, 20));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(330, 20));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(h2 = new StreetHub());
			h2.Connect(c3);
			Save(c4 = new StreetConnector(370, 20));
			h2.Connect(c4);
			Save(c5 = new StreetConnector(420, 20));
			Save(new Building(c5));
			Save(new StreetSegment(c4, c5));
			Save(h3 = new StreetHub());
			h3.Connect(c5);
			Save(c6 = new StreetConnector(400, 50));
			Save(new Building(c6));
			h3.Connect(c6);
			Save(c7 = new StreetConnector(420, 50));
			Save(new Building(c7));
			Save(new StreetSegment(c6, c7));
			h3.Connect(c7);

			// street down left at upper right
			Save(c1 = new StreetConnector(350, 30));
			h2.Connect(c1);
			Save(c2 = new StreetConnector(350, 80));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(350, 130));
			Save(new StreetSegment(c2, c3));
			Save(c4 = new StreetConnector(340, 150));
			Save(new StreetSegment(c3, c4));
			Save(c5 = new StreetConnector(310, 150));
			Save(new StreetSegment(c4, c5));
			Save(h2 = new StreetHub());
			h2.Connect(c5);

			// umbrella like construct upper right
			Save(c1 = new StreetConnector(290, 140));
			h2.Connect(c1);
			Save(c2 = new StreetConnector(290, 100));
			Save(new StreetSegment(c1, c2));
			Save(h3 = new StreetHub());
			h3.Connect(c2);
			Save(c3 = new StreetConnector(270, 90));
			Save(new Building(c3));
			h3.Connect(c3);
			Save(c4 = new StreetConnector(240, 90));
			Save(new Building(c4));
			Save(new StreetSegment(c3, c4));
			Save(c5 = new StreetConnector(260, 60));
			Save(new StreetSegment(c4, c5));
			Save(c6 = new StreetConnector(310, 60));
			Save(new Building(c6));
			Save(new StreetSegment(c5, c6));
			Save(c7 = new StreetConnector(330, 90));
			Save(new Building(c7));
			Save(new StreetSegment(c6, c7));
			Save(c8 = new StreetConnector(310, 90));
			Save(new Building(c8));
			Save(new StreetSegment(c7, c8));
			h3.Connect(c8);

			// long street mid left from mid hub
			Save(c1 = new StreetConnector(170, 150));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(120, 150));
			Save(new Building(c2));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(50, 170));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(c4 = new StreetConnector(20, 200));
			Save(new Building(c4));
			Save(new StreetSegment(c3, c4));
			Save(c5 = new StreetConnector(20, 230));
			Save(new StreetSegment(c4, c5));
			Save(c6 = new StreetConnector(110, 230));
			Save(new StreetSegment(c5, c6));
			Save(h3 = new StreetHub());
			h3.Connect(c6);

			// circle bottom left
			Save(c1 = new StreetConnector(50, 260));
			Save(new Building(c1));
			Save(h4 = new StreetHub());
			h4.Connect(c1);
			Save(c2 = new StreetConnector(10, 270));
			Save(new Building(c2));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(50, 290));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(c4 = new StreetConnector(60, 270));
			Save(new StreetSegment(c3, c4));
			h4.Connect(c4);

			// short street from circle to next hub
			Save(c1 = new StreetConnector(90, 260));
			h4.Connect(c1);
			Save(c2 = new StreetConnector(120, 270));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(130, 240));
			Save(new StreetSegment(c2, c3));
			h3.Connect(c3);

			// continue street from above down at the bottom
			Save(c1 = new StreetConnector(150, 230));
			Save(new Building(c1));
			h3.Connect(c1);
			Save(c2 = new StreetConnector(190, 280));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(250, 280));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(h3 = new StreetHub());
			h3.Connect(c3);

			// single segment to the lower left from the umbrella like construct
			Save(c1 = new StreetConnector(230, 150));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(270, 150));
			Save(new StreetSegment(c1, c2));
			h2.Connect(c2);

			// two L-like segments at lower mid
			Save(c1 = new StreetConnector(200, 180));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(200, 250));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(240, 250));
			Save(new StreetSegment(c2, c3));
			h3.Connect(c3);

			// hub connect below umbrella like construct
			Save(c1 = new StreetConnector(290, 180));
			h2.Connect(c1);
			Save(h1 = new StreetHub());
			h1.Connect(c1);

			// lower left segment to above section
			Save(c1 = new StreetConnector(270, 200));
			Save(new Building(c1));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(260, 240));
			Save(new StreetSegment(c1, c2));
			h3.Connect(c2);

			// lower right segment to above section
			Save(c1 = new StreetConnector(320, 200));
			Save(new Building(c1));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(330, 240));
			Save(new StreetSegment(c1, c2));
			Save(h1 = new StreetHub());
			h1.Connect(c2);

			// connection segment to both above sections
			Save(c1 = new StreetConnector(280, 250));
			h3.Connect(c1);
			Save(c2 = new StreetConnector(310, 250));
			Save(new StreetSegment(c1, c2));
			h1.Connect(c2);

			// segment below above section
			Save(c1 = new StreetConnector(270, 280));
			h3.Connect(c1);
			Save(c2 = new StreetConnector(330, 270));
			Save(new StreetSegment(c1, c2));
			h1.Connect(c2);

			// little segment between hub and bottom right circle
			Save(c1 = new StreetConnector(350, 250));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(370, 250));
			Save(new StreetSegment(c1, c2));
			Save(h1 = new StreetHub());
			h1.Connect(c2);

			// bottom right circle
			Save(c1 = new StreetConnector(380, 240));
			Save(new Building(c1));
			h1.Connect(c1);
			Save(c2 = new StreetConnector(420, 220));
			Save(new Building(c2));
			Save(new StreetSegment(c1, c2));
			Save(c3 = new StreetConnector(420, 260));
			Save(new Building(c3));
			Save(new StreetSegment(c2, c3));
			Save(c4 = new StreetConnector(380, 260));
			Save(new StreetSegment(c3, c4));
			h1.Connect(c4);
		}

		private static void Save(StreetConnector connector) {
			connectors.Add(connector.ID, connector);
		}
		private static void Save(StreetHub hub) {
			hubs.Add(hub.ID, hub);
		}
		private static void Save(StreetSegment segment) {
			segments.Add(segment.ID, segment);
		}
		private static void Save(Building building) {
			buildings.Add(building.ID, building);
		}
		private static void Save(PublicTransportStation station) {
			stations.Add(station.ID, station);
		}


		/// <summary>
		/// Creates new StreetMap-Element instances.
		/// </summary>
		public static class Factory {
			/// <summary>
			/// Creates a new StreetConnector and returns it.
			/// </summary>
			/// <param name="coordinate">The coordinate of the StreetConnector</param>
			/// <returns>A new instance of a StreetConnector</returns>
			public static StreetConnector NewStreetConnector(Coordinate coordinate) {
				StreetConnector connector = new StreetConnector(coordinate);
				connectors.Add(connector.ID, connector);
				return connector;
			}

			/// <summary>
			/// Creates a new StreetHub and returns it.
			/// </summary>
			/// <returns>A new instance of a StreetHub</returns>
			public static StreetHub NewStreetHub() {
				StreetHub hub = new StreetHub();
				hubs.Add(hub.ID, hub);
				return hub;
			}

			/// <summary>
			/// Creates a new StreetSegment and returns it.
			/// </summary>
			/// <param name="c1">The first StreetConnector</param>
			/// <param name="c2">The second StreetConnector</param>
			/// <returns>A new instance of a StreetSegment</returns>
			public static StreetSegment NewStreetSegment(StreetConnector c1, StreetConnector c2) {
				StreetSegment segment = new StreetSegment(c1, c2);
				segments.Add(segment.ID, segment);
				return segment;
			}

			/// <summary>
			/// Creates a new Building and returns it.
			/// </summary>
			/// <param name="connector">The assoziated StreetConnector</param>
			/// <returns>A new instance of a Building</returns>
			public static Building NewBuilding(StreetConnector connector) {
				Building building = new Building(connector);
				buildings.Add(building.ID, building);
				return building;
			}

			/// <summary>
			/// Creates a new TramStation and returns it.
			/// </summary>
			/// <param name="connector">The assoziated StreetConnector</param>
			/// <returns>A new instance of a TramStation</returns>
			public static TramStation NewTramStation(StreetConnector connector) {
				TramStation station = new TramStation(connector);
				stations.Add(station.ID, station);
				return station;
			}

			/// <summary>
			/// Creates a new BusStation and returns it.
			/// </summary>
			/// <param name="connector">The assoziated StreetConnector</param>
			/// <returns>A new instance of a BusStation</returns>
			public static BusStation NewBusStation(StreetConnector connector) {
				BusStation station = new BusStation(connector);
				stations.Add(station.ID, station);
				return station;
			}
		}

		/// <summary>
		/// Allows access to the StreetMap data.
		/// </summary>
		public static class Data {
			/// <summary>
			/// Gets the total count of StreetConnectors.
			/// </summary>
			public static int StreetConnectorsCount { get { return connectors.Count; } }
			/// <summary>
			/// Gets the total count of StreetHubs.
			/// </summary>
			public static int StreetHubsCount { get { return hubs.Count; } }
			/// <summary>
			/// Gets the total count of StreetSegments.
			/// </summary>
			public static int StreetSegmentsCount { get { return segments.Count; } }
			/// <summary>
			/// Gets the total count of Buildings.
			/// </summary>
			public static int BuildingsCount { get { return buildings.Count; } }
			/// <summary>
			/// Gets the total count of PublicTransportStations.
			/// </summary>
			public static int PublicTransportStationsCount { get { return stations.Count; } }


			/// <summary>
			/// Returns the StreetConnector with the given id.
			/// </summary>
			/// <param name="id">The requested id</param>
			/// <returns>The StreetConnector</returns>
			public static StreetConnector StreetConnectors(int id) {
				StreetConnector connector;
				if (connectors.TryGetValue(id, out connector)) {
					return connector;
				}

				ReportManager.PrintError("There is no StreetConnector with the given id!");
				return null;
			}

			/// <summary>
			/// Returns the StreetHub with the given id.
			/// </summary>
			/// <param name="id">The requested id</param>
			/// <returns>The StreetHub</returns>
			public static StreetHub StreetHubs(int id) {
				StreetHub hub;
				if (hubs.TryGetValue(id, out hub)) {
					return hub;
				}

				ReportManager.PrintError("There is no StreetHub with the given id!");
				return null;
			}

			/// <summary>
			/// Returns the StreetSegment with the given id.
			/// </summary>
			/// <param name="id">The requested id</param>
			/// <returns>The StreetSegment</returns>
			public static StreetSegment StreetSegments(int id) {
				StreetSegment segment;
				if (segments.TryGetValue(id, out segment)) {
					return segment;
				}

				ReportManager.PrintError("There is no StreetSegment with the given id!");
				return null;
			}

			/// <summary>
			/// Returns the Building with the given id.
			/// </summary>
			/// <param name="id">The requested id</param>
			/// <returns>The Building</returns>
			public static Building Buildings(int id) {
				Building building;
				if (buildings.TryGetValue(id, out building)) {
					return building;
				}

				ReportManager.PrintError("There is no Building with the given id!");
				return null;
			}

			/// <summary>
			/// Returns the PublicTransportStation with the given id.
			/// </summary>
			/// <param name="id">The requested id</param>
			/// <returns>The PublicTransportStation</returns>
			public static PublicTransportStation PublicTransportStations(int id) {
				PublicTransportStation station;
				if (stations.TryGetValue(id, out station)) {
					return station;
				}

				ReportManager.PrintError("There is no PublicTransportStation with the given id!");
				return null;
			}
		}
	}
}
