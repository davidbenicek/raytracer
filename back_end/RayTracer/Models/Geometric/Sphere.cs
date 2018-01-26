using System;
using RayTracer.Models.Elements;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Models.Geometric
{
    public class Sphere: GeometryObject
    {
        Point3D center;
        double radius;

        public Sphere()
            :base()
        {
            center = new Point3D();
            radius = Config.DEFAULT_RADIUS;
        }

        public Sphere(Point3D center, double radius, Material material)
            :base(material)
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
