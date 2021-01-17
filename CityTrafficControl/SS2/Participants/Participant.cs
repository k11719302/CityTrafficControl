using CityTrafficControl.Master;
using CityTrafficControl.Master.DataStructures;
using CityTrafficControl.Master.StreetMap;
using CityTrafficControl.SS2.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.Participants {
	abstract class Participant : IIDSupport {
		private static int nextID;

		protected int id;
		protected Building currentBuilding;
		protected StreetConnector currentConnector;
		protected ParticipantPosition position;
		protected double maxSpeed;
		protected double accidentRisk;
		protected double size;

		protected BaseRoute baseRoute;
		protected SpecialRoute specialRoute;
		protected RoutingState currentRoutingState;
		protected StreetConnector lastConnector;
		protected StreetConnector nextConnector;
		protected StreetConnector goalConnector;
		protected TimeSpan timeBonus;
		protected int currentWaypointIndex;
		protected bool claimedSpace;
		protected bool isFirstClaim;


		static Participant() {
			nextID = 0;
		}


		protected Participant(StreetConnector position, double maxSpeed, double accidentRisk, double size) {
			id = NextID;
			currentConnector = position;
			this.position = ParticipantPosition.FromCoordinate(position.Coordinate);
			this.maxSpeed = maxSpeed;
			this.accidentRisk = accidentRisk;
			this.size = size;

			baseRoute = null;
			specialRoute = null;
			currentRoutingState = RoutingState.Idle;
			lastConnector = null;
			nextConnector = null;
			goalConnector = null;
			timeBonus = TimeSpan.Zero;
			claimedSpace = false;
			isFirstClaim = true;
		}
		protected Participant(Building position, double maxSpeed, double accidentRisk, double size) : this(position.Connector, maxSpeed, accidentRisk, size) {
			currentBuilding = position;
		}
		// TODO: Delete empty constructor
		protected Participant() {
			id = NextID;
			currentConnector = StreetMapManager.Data.StreetConnectors(0);
			this.position = ParticipantPosition.FromCoordinate(currentConnector.Coordinate);
			this.maxSpeed = 50;
			this.accidentRisk = 0;
			this.size = 1;

			baseRoute = null;
			specialRoute = null;
			currentRoutingState = RoutingState.Idle;
			lastConnector = null;
			nextConnector = null;
			goalConnector = null;
			timeBonus = TimeSpan.Zero;
			claimedSpace = false;
			isFirstClaim = true;

			ReportManager.PrintError("Invalid Participant contructor called!");
			//throw new Exception("Temporary constructor called");
		}


		private static int NextID { get { return nextID++; } }


		public int ID { get { return id; } }
		public Building CurrentBuilding { get { return currentBuilding; } }
		public StreetConnector CurrentConnector { get { return currentConnector; } }
		public ParticipantPosition Position { get { return position; } }
		public double MaxSpeed { get { return maxSpeed; } }
		public double AccidentRisk { get { return accidentRisk; } }
		public double Size { get { return size; } }

		public bool IsInBuilding { get { return currentBuilding != null; } }


		public virtual void SimulateTick() {
			timeBonus = timeBonus.Add(Master.SimulationManager.TickDuration);
		}

		public void StartNewRoute(StreetConnector goal) {
			goalConnector = goal;
			if (goal == currentConnector) {
				currentRoutingState = RoutingState.Finished;
				return;
			}
			baseRoute = RouteManager.GetBestBaseRoute(currentConnector, goal);
			if (baseRoute == null) {
				specialRoute = RouteManager.GetSpecialRoute(currentConnector, goal);
				currentRoutingState = RoutingState.SpecialStart2;
			}
			else {
				if (baseRoute.Start == currentConnector) {
					currentRoutingState = RoutingState.BaseStart;
				}
				else {
					specialRoute = RouteManager.GetSpecialRoute(currentConnector, baseRoute.Start);
					currentRoutingState = RoutingState.SpecialStart1;
				}
			}
		}

		public void ExecuteRouting() {
			bool executing = true;

			while (executing) {
				switch (currentRoutingState) {
					case RoutingState.Idle: case RoutingState.Starting: return;
					case RoutingState.SpecialStart1:
						if (specialRoute.Waypoints.Count == 0) {
							currentRoutingState = RoutingState.SpecialEnd1;
							continue;
						}
						nextConnector = specialRoute.Waypoints.First();
						if (executing = AdvanceRoute()) {
							currentRoutingState = RoutingState.SpecialWayspoints1;
							currentWaypointIndex = 1;
						}
						break;
					case RoutingState.SpecialWayspoints1:
						if (specialRoute.Waypoints.Count == currentWaypointIndex) {
							currentRoutingState = RoutingState.SpecialEnd1;
							continue;
						}
						nextConnector = specialRoute.Waypoints.ElementAt(currentWaypointIndex);
						if (executing = AdvanceRoute()) {
							currentWaypointIndex++;
						}
						break;
					case RoutingState.SpecialEnd1:
						nextConnector = specialRoute.End;
						if (executing = AdvanceRoute()) {
							currentRoutingState = RoutingState.BaseStart;
						}
						break;
					case RoutingState.BaseStart:
						if (baseRoute.Waypoints.Count == 0) {
							currentRoutingState = RoutingState.BaseEnd;
							continue;
						}
						nextConnector = baseRoute.Waypoints.First();
						if (executing = AdvanceRoute()) {
							currentRoutingState = RoutingState.BaseWaypoints;
							currentWaypointIndex = 1;
						}
						break;
					case RoutingState.BaseWaypoints:
						if (baseRoute.Waypoints.Count == currentWaypointIndex) {
							currentRoutingState = RoutingState.BaseEnd;
							continue;
						}
						nextConnector = baseRoute.Waypoints.ElementAt(currentWaypointIndex);
						if (executing = AdvanceRoute()) {
							currentWaypointIndex++;
						}
						break;
					case RoutingState.BaseEnd:
						nextConnector = baseRoute.End;
						if (executing = AdvanceRoute()) {
							if (currentConnector == goalConnector) {
								currentRoutingState = RoutingState.Finished;
							}
							else {
								specialRoute = new SpecialRoute(currentConnector, goalConnector);
								currentRoutingState = RoutingState.SpecialStart2;
							}
						}
						break;
					case RoutingState.SpecialStart2:
						if (specialRoute.Waypoints.Count == 0) {
							currentRoutingState = RoutingState.SpecialEnd2;
							continue;
						}
						nextConnector = specialRoute.Waypoints.First();
						if (executing = AdvanceRoute()) {
							currentRoutingState = RoutingState.SpecialWayspoints2;
							currentWaypointIndex = 1;
						}
						break;
					case RoutingState.SpecialWayspoints2:
						if (specialRoute.Waypoints.Count == currentWaypointIndex) {
							currentRoutingState = RoutingState.SpecialEnd2;
							continue;
						}
						nextConnector = specialRoute.Waypoints.ElementAt(currentWaypointIndex);
						if (executing = AdvanceRoute()) {
							currentWaypointIndex++;
						}
						break;
					case RoutingState.SpecialEnd2:
						nextConnector = specialRoute.End;
						if (executing = AdvanceRoute()) {
							currentRoutingState = RoutingState.Finished;
						}
						break;
					case RoutingState.Finished:
						if (!isFirstClaim) {
							StreetType typeLast;
							if (currentConnector.EP1.FindNeighbours().Contains(lastConnector)) {
								typeLast = currentConnector.EP1.Self;
							}
							else {
								typeLast = currentConnector.EP2.Self;
							}
							FreeSpace(typeLast);
						}
						isFirstClaim = true;
						return;
					default: throw new Exception("Unknown RoutingState");
				}
			}
		}

		public override string ToString() {
			return string.Format("Participant({0})", id);
		}


		protected bool AdvanceRoute() {
			StreetType typeCur, typeLast;
			TimeSpan requiredTime;

			if (currentConnector.EP1.FindNeighbours().Contains(nextConnector)) {
				typeCur = currentConnector.EP1.Self;
				typeLast = currentConnector.EP2.Self;
			}
			else {
				typeCur = currentConnector.EP2.Self;
				typeLast = currentConnector.EP1.Self;
			}

			if (typeCur is StreetSegment) {
				StreetSegment segment = (StreetSegment)typeCur;

				if (!claimedSpace) {
					int direction = segment.EP1.Connector == currentConnector ? 1 : 2;
					if (!segment.ClaimSpace(direction, size)) {
						timeBonus = TimeSpan.Zero;
						return false;
					}
					if (isFirstClaim) {
						isFirstClaim = false;
					}
					else {
						FreeSpace(typeLast);
					}
					claimedSpace = true;
				}

				requiredTime = maxSpeed < segment.SpeedLimit ? TimeSpan.FromSeconds(segment.Length / maxSpeed) : segment.MinDriveTime;
				if (requiredTime.CompareTo(timeBonus) > 0) {
					return false;
				}

				timeBonus = timeBonus.Subtract(requiredTime);
				lastConnector = currentConnector;
				currentConnector = nextConnector;
				nextConnector = null;
				claimedSpace = false;
				ReportManager.PrintDebug(this + " advanced to " + currentConnector + ".");
				return true;
			}
			else if (typeCur is StreetHub) {
				StreetHub hub = (StreetHub)typeCur;

				if (!claimedSpace) {
					if (!hub.ClaimSpace(size)) {
						timeBonus = TimeSpan.Zero;
						return false;
					}
					if (isFirstClaim) {
						isFirstClaim = false;
					}
					else {
						FreeSpace(typeLast);
					}
					claimedSpace = true;
				}

				double speed = maxSpeed < hub.SpeedLimit ? maxSpeed : hub.SpeedLimit;
				requiredTime = TimeSpan.FromSeconds(Coordinate.GetDistance(currentConnector.Coordinate, nextConnector.Coordinate) / speed);
				if (requiredTime.CompareTo(timeBonus) > 0) {
					return false;
				}

				timeBonus = timeBonus.Subtract(requiredTime);
				lastConnector = currentConnector;
				currentConnector = nextConnector;
				nextConnector = null;
				claimedSpace = false;
				return true;
			}
			else throw new StreetMapException("Unknown StreetType");
		}

		protected void FreeSpace(StreetType last) {
			if (last is StreetSegment) {
				StreetSegment segment = (StreetSegment)last;
				int direction = segment.EP1.Connector == currentConnector ? 2 : 1;
				segment.FreeSpace(direction, size);
			}
			else if (last is StreetHub) {
				StreetHub hub = (StreetHub)last;
				hub.FreeSpace(size);
			}
			else throw new StreetMapException("Unknown StreetType");
		}


		public enum RoutingState {
			Idle, Starting,
			SpecialStart1, SpecialWayspoints1, SpecialEnd1,
			BaseStart, BaseWaypoints, BaseEnd,
			SpecialStart2, SpecialWayspoints2, SpecialEnd2,
			Finished
		}
	}
}
