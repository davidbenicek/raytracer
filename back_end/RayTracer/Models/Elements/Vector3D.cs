using System;
namespace RayTracer.Models.Elements
{
    public class Vector3D
    {
        public double x { set; get; }
        public double y { set; get; }
        public double z { set; get; }

        public Vector3D()
        {
            x = 0.0;
            y = 0.0;
            z = 0.0;
        }

        public Vector3D(double V)
        {
            x = V;
            y = V;
            z = V;
        }

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3D(Vector3D vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }
        //This function overload the sum operation between two vectors and return a new vector
        public static Vector3D operator +(Vector3D vectorA, Vector3D vectorB)
        {
            return new Vector3D(vectorA.x + vectorB.x, vectorA.y + vectorB.y, vectorA.z + vectorB.z);
        }
        //This function overload the subtract operation between two vectors and return a new vector
        public static Vector3D operator -(Vector3D vectorA, Vector3D vectorB)
        {
            return new Vector3D(vectorA.x - vectorB.x, vectorA.y - vectorB.y, vectorA.z - vectorB.z);
        }
        //This function overload -Vector operation, which is equivalent to -1 * Vector
        public static Vector3D operator -(Vector3D vector)
        {
            return new Vector3D(-1 * vector.x, -1 * vector.y, -1 * vector.z);
        }
        //This function overload the multiplication of a vector by a scale
        public static Vector3D operator *(Vector3D vector, double Scale)
        {
            return new Vector3D(vector.x * Scale, vector.y * Scale, vector.z * Scale);
        }
        //This function overload the multiplication of a scale by a vector
        public static Vector3D operator *(double Scale, Vector3D vector)
        {
            return new Vector3D(vector.x * Scale, vector.y * Scale, vector.z * Scale);
        }
        //This function overload the division of a vector by a scale
        public static Vector3D operator /(Vector3D vector, double Scale)
        {
            return new Vector3D(vector.x / Scale, vector.y / Scale, vector.z / Scale);
        }
        //This function will perform the dot product between two vectors
        public double DotProduct(Vector3D vector)
        {
            return x * vector.x + y * vector.y + z * vector.z;
        }
        //This function will perform the cross product between two vectors
        public Vector3D CrossProduct(Vector3D vector)
        {
            double zy = y * vector.z - z * vector.y;
            double zx = z * vector.x - x * vector.z;
            double xy = x * vector.y - y * vector.x;


            return new Vector3D(zy, zx, xy);
        }
        //This function will calculate the square value of vector's length
        public double LengthBeforeSqrt()
        {
            double x2 = x * x;
            double y2 = y * y;
            double z2 = z * z;

            double sum = x2 + y2 + z2;
            return sum;
        }
        //This function will calculate the length of the Vector
        public double Length()
        {
            return Math.Sqrt(LengthBeforeSqrt());
        }
        //This function will normalize the vector, by dividing x,y,z by the length of the vector
        public void Normalize()
        {
            if (Length() > 0)
            {
                x /= Length();
                y /= Length();
                z /= Length();
            }
        }

        public Vector3D Mix(Vector3D vectorA, Vector3D vectorB, double MixValue)
        {
            return vectorA * (1 - MixValue) + vectorB * MixValue;
        }
    }

}
