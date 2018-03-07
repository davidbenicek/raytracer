using System;
namespace RayTracer.Models.Elements
{
    public class Point2D
    {
        public double x;
        public double y;

        public Point2D()
        {
            this.x = 0.0;
            this.y = 0.0;
        }

        public Point2D(double value)
        {
            this.x = value;
            this.y = value;
        }

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(Object obj)
        {
            Point2D point = (Point2D)obj;
            return point.x.Equals(x) && point.y.Equals(y);
        }
    }
}
