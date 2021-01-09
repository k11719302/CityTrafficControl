using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficControlAndDetection
{
    class Position
    {
        private int x;
        public int X { get => x; set => x = value; }

        private int y;
        public int Y { get => y; set => y = value; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
