using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS3
{
    class TrafficParticipant
    {
        private int id;
        private Path path;
        private Road position;
        private Road destination;
        private List<RoadRestrictionTypes> restrictions;

        TrafficParticipant(int id, Road position, Road destination, List<RoadRestrictionTypes> restrictions)
        {
            this.id = id;
            this.position = position;
            this.destination = destination;
            this.restrictions = restrictions;
            path = null;
        }

        private int Id { get { return id; } }
        private Path Path { get { return path; } }
        private Road Position { get { return position; } }
        private Road Destination { get { return destination; } }
        private List<RoadRestrictionTypes> Restrictions { get { return restrictions; } }
    }
}
