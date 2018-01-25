using System;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Geometric
{
    public class Sphere: GeometryObject
    {
        Point3D center;
        double radius;

        public Sphere()
        {
            center = new Point3D();
            radius = Config.DEFAULT_RADIUS;
        }

        public Sphere(Point3D center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override HitInfo Intersect(Ray ray)
        {
            throw new NotImplementedException();
        }
    }
}
