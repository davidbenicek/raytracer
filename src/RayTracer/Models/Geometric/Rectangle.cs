using RayTracer.Models.Elements;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Models.Geometric
{
    public class Rectangle : GeometryObject
    {
        Point3D position;
        Vector3D vectorA;
        Vector3D vectorB;

        public Rectangle(Point3D position, Vector3D vectorA, Vector3D vectorB, Material material)
            : base(material)
        {
            this.position = position;
            this.vectorA = vectorA;
            this.vectorB = vectorB;
        }

        public override HitInfo Intersect(Ray ray)
        {
            HitInfo hitInfo = new HitInfo();
            Vector3D normal = vectorA.CrossProduct(vectorB);
            normal.Normalize();

            double t = (position - ray.origin).DotProduct(normal) / ray.direction.DotProduct(normal);

            if (t < Config.KEPSILON_VALUE)
            {
                hitInfo.hasHit = false;
                return hitInfo;
            }

            Point3D hitPoint = ray.origin + t * ray.direction;
            Vector3D direction = hitPoint - position;

            double directionDotvectorA = direction.DotProduct(vectorA);

            if (directionDotvectorA < 0 || directionDotvectorA > vectorA.LengthBeforeSqrt())
            {
                hitInfo.hasHit = false;
                return hitInfo;
            }

            double directionDotvectorB = direction.DotProduct(vectorB);

            if (directionDotvectorB < 0 || directionDotvectorB > vectorB.LengthBeforeSqrt())
            {
                hitInfo.hasHit = false;
                return hitInfo;
            }

            hitInfo.hasHit = true;
            hitInfo.hitObject = this;
            hitInfo.hitPoint = hitPoint;
            hitInfo.normalAtHit = normal;
            hitInfo.ray = ray;
            hitInfo.tMin = t;

            return hitInfo;
        }
    }
}

