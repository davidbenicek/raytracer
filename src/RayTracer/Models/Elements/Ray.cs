using System;

namespace RayTracer.Models.Elements
{
    public class Ray
    {
        public Point3D origin { set; get; }
        public Vector3D direction { set; get; }

        public Ray()
        {
            origin = new Point3D();
            direction = new Vector3D();
        }

        public Ray(Point3D origin, Vector3D direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        public Ray(Ray ray)
        {
            origin = ray.origin;
            direction = ray.direction;
        }
    }
}
