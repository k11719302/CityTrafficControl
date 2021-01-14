using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;

namespace CityTrafficControl.SS1
{
    public interface Sensor
    {
        int Id { get; }
        Coordinate Position { get; }
        States State { get; set; }
    }

    public enum States
    {
        BROKEN,
        ACTIVE,
        INACTIVE
    }
}
