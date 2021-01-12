using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS1
{
    public interface Sensor
    {
        int Id { get; }
        Position Position { get; }
        States State { get; set; }
    }

    public enum States
    {
        BROKEN,
        ACTIVE,
        INACTIVE
    }
}
