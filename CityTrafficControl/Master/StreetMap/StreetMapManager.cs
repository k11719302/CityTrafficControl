using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.StreetMap {
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


		public static void Init() {
			if (isInitialized) {
				ReportManager.PrintError("StreetMapManager already initialized!");
				return;
			}

			isInitialized = true;
			InitStaticMap();
			ReportManager.PrintOutput("StreetMapManager initialized.");
		}

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


		public static class Factory {
			public static StreetConnector NewStreetConnector(Coordinate coordinate) {
				StreetConnector connector = new StreetConnector(coordinate);
				connectors.Add(connector.ID, connector);
				return connector;
			}

			public static StreetHub NewStreetHub() {
				StreetHub hub = new StreetHub();
				hubs.Add(hub.ID, hub);
				return hub;
			}

			public static StreetSegment NewStreetSegment(StreetConnector c1, StreetConnector c2) {
				StreetSegment segment = new StreetSegment(c1, c2);
				segments.Add(segment.ID, segment);
				return segment;
			}

			public static Building NewBuilding(StreetConnector connector) {
				Building building = new Building(connector);
				buildings.Add(building.ID, building);
				return building;
			}

			public static TramStation NewTramStation(StreetConnector connector) {
				TramStation station = new TramStation(connector);
				stations.Add(station.ID, station);
				return station;
			}

			public static BusStation NewBusStation(StreetConnector connector) {
				BusStation station = new BusStation(connector);
				stations.Add(station.ID, station);
				return station;
			}
		}

		public static class Data {
			public static int StreetConnectorsCount { get { return connectors.Count; } }
			public static int StreetHubsCount { get { return hubs.Count; } }
			public static int StreetSegmentsCount { get { return segments.Count; } }
			public static int BuildingsCount { get { return buildings.Count; } }
			public static int PublicTransportStationsCount { get { return stations.Count; } }


			public static StreetConnector StreetConnectors(int id) {
				StreetConnector connector;
				if (connectors.TryGetValue(id, out connector)) {
					return connector;
				}

				ReportManager.PrintError("There is no StreetConnector with the given id!");
				return null;
			}

			public static StreetHub StreetHubs(int id) {
				StreetHub hub;
				if (hubs.TryGetValue(id, out hub)) {
					return hub;
				}

				ReportManager.PrintError("There is no StreetHub with the given id!");
				return null;
			}

			public static StreetSegment StreetSegments(int id) {
				StreetSegment segment;
				if (segments.TryGetValue(id, out segment)) {
					return segment;
				}

				ReportManager.PrintError("There is no StreetSegment with the given id!");
				return null;
			}

			public static Building Buildings(int id) {
				Building building;
				if (buildings.TryGetValue(id, out building)) {
					return building;
				}

				ReportManager.PrintError("There is no Building with the given id!");
				return null;
			}

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
