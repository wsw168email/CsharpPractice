using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformTCPClient
{
    internal class Ship
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Speed { get; set; }
        public double Course { get; set; }

        public Ship(double x, double y, double speed, double course)
        {
            X = x;
            Y = y;
            Speed = speed;
            Course = course;
        }
    }

}
