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

		private static void InitStaticMap() {
			throw new NotImplementedException();
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
