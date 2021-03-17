using System;

namespace PointLib
{
    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public double getModule()
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
}