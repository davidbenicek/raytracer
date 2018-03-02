using System;
namespace RayTracer.Models.Elements
{
    public class Point3D
    {
        public double x;
        public double y;
        public double z;

        public Point3D()
        {
            x = 0.0;
            y = 0.0;
            z = 0.0;
        }

        public Point3D(double value)
        {
            x = value;
            y = value;
            z = value;
        }

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D(Point3D Point)
        {
            x = Point.x;
            y = Point.y;
            z = Point.z;
        }

        //This overloads the method + to make it add two points, and return a point
        public static Point3D operator +(Point3D Point, Point3D pointB)
        {
            return new Point3D(Point.x + pointB.x, Point.y + pointB.y, Point.z + pointB.z);
        }

        //This overloads the method + to make it add a point with a vector, and return a point
        public static Point3D operator +(Point3D point, Vector3D vector)
        {
            return new Point3D(point.x + vector.x, point.y + vector.y, point.z + vector.z);
        }
        //This function overloads the subtraction of two points, and return a point

        public static Point3D operator -(Point3D point, Vector3D vector)
        {
            return new Point3D(point.x - vector.x, point.y - vector.y, point.z - vector.z);
        }

        //This function overloads the subtraction of two points, and return a vector
        public static Vector3D operator -(Point3D pointA, Point3D pointB)
        {
            return new Vector3D(pointA.x - pointB.x, pointA.y - pointB.y, pointA.z - pointB.z);
        }
        //This function overloads the mulitplication of two points, and return a point
        public static Point3D operator *(Point3D point, double scale)
        {
            return new Point3D(point.x * scale, point.y * scale, point.z * scale);
        }
        //This function overloads the mulitplication method, and return a point
        public static Point3D operator *(double scale, Point3D point)
        {
            return new Point3D(point.x * scale, point.y * scale, point.z * scale);
        }
        //This function will calculate the distance between two points before taking the square root
        public double GetDistanceBeforeSqrt(Point3D point)
        {
            double x2 = (x - point.x) * (x - point.x);
            double y2 = (y - point.y) * (y - point.y);
            double z2 = (z - point.z) * (z - point.z);

            double sum = x2 + y2 + z2;

            return sum;
        }
        //This function will return the distance between two points
        public double GetDistance(Point3D point)
        {
            double sum = GetDistanceBeforeSqrt(point);
            return Math.Sqrt(sum);
        }

        public override bool Equals(Object obj)
        {
            Point3D point = (Point3D)obj;
            return point.x.Equals(x) && point.y.Equals(y) && point.z.Equals(z);
        }
    }
}
