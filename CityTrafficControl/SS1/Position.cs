using System;
using System.Collections.Generic;
using System.Text;

namespace CityTrafficControl.SS1
{
    class Position
    {
        private int x;
        public int X { get { return x; } set { x = value; } }

        private int y;
        public int Y { get { return y; } set { y = value; } }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
