using System;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;

namespace RayTracer.Models.Util
{
    public class HitInfo
    {
        public bool hasHit;
        public Point3D hitPoint;
        public Vector3D normalAtHit;
        public Ray ray;
        public GeometryObject hitObject;
        public double tMin;

        public HitInfo()
        {
            hasHit = false;
            hitPoint = new Point3D();
            normalAtHit = new Vector3D();
            ray = new Ray();
        }

        public HitInfo(HitInfo hitInfo)
        {
            hasHit = hitInfo.hasHit;
            hitPoint = hitInfo.hitPoint;
            normalAtHit = hitInfo.normalAtHit;
            hitObject = hitInfo.hitObject;
            tMin = hitInfo.tMin;
        }

        public HitInfo(bool HitObject, double tMin, Point3D hitPoint, Vector3D normalAtHit, GeometryObject hitObject)
        {
            this.hitPoint = hitPoint;
            this.hasHit = HitObject;
            this.normalAtHit = normalAtHit;
            this.hitObject = hitObject;
            this.tMin = tMin;
        }
    }
}
