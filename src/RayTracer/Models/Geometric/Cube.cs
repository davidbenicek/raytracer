//This is the Cube Intersect Method
using System;
using RayTracer.Models.Elements;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Models.Geometric
{
    public class Cube : GeometryObject
    {
        //The Minimum and Maximum co-ordinates of the cube
        public Point3D minPoint;
        public Point3D maxPoint;

        public Cube()
            : base()
        {
            minPoint = new Point3D();
            maxPoint = new Point3D();
        }

        //New Implementation
        public Cube(Point3D Point, Point3D size, Material material)
            : base(material)
        {
            Point.y -= size.y;
            this.minPoint = Point;

            Point3D tempPoint = new Point3D(Point);
            tempPoint.y += size.y;
            tempPoint.x += size.x;
            this.maxPoint = tempPoint;
        }

        //Narg made a change

        public override HitInfo Intersect(Ray ray)
        {
            //This is the method that performs the calculation to determine whether 
            //a given ray hits a cube or not
            HitInfo intersectionObject = new HitInfo();
            double txMin, tyMin, tzMin;
            double txMax, tyMax, tzMax;
            //X axis Values
            if (ray.direction.x >= 0)
            {
                txMin = (minPoint.x - ray.origin.x) / ray.direction.x;
                txMax = (maxPoint.x - ray.origin.x) / ray.direction.x;
            }
            else
            {
                txMax = (minPoint.x - ray.origin.x) / ray.direction.x;
                txMin = (maxPoint.x - ray.origin.x) / ray.direction.x;
            }
            //Y axis values
            if (ray.direction.y >= 0)
            {
                tyMin = (minPoint.y - ray.origin.y) / ray.direction.y;
                tyMax = (maxPoint.y - ray.origin.y) / ray.direction.y;
            }
            else
            {
                tyMax = (minPoint.y - ray.origin.y) / ray.direction.y;
                tyMin = (maxPoint.y - ray.origin.y) / ray.direction.y;
            }
            //Z axis values
            if (ray.direction.z >= 0)
            {
                tzMin = (minPoint.z - ray.origin.z) / ray.direction.z;
                tzMax = (maxPoint.z - ray.origin.z) / ray.direction.z;
            }
            else
            {
                tzMax = (minPoint.z - ray.origin.z) / ray.direction.z;
                tzMin = (maxPoint.z - ray.origin.z) / ray.direction.z;
            }

            if (txMin > tyMax || tyMin > txMax)
            {
                intersectionObject.hasHit = false;
                return intersectionObject;
            }

            if (tyMin > txMin)
                txMin = tyMin;

            if (tyMax < txMax)
                txMax = tyMax;

            if (txMin > tzMax || tzMin > txMax)
            {
                intersectionObject.hasHit = false;
                return intersectionObject;
            }

            if (tzMin > txMin)
                txMin = tzMin;

            if (tzMax < txMax)
                txMax = tzMax;
            //#Beware
            if (txMin < 0)
                txMin = txMax;
            if (txMin < 0)
            {
                intersectionObject.hasHit = false;
                return intersectionObject;
            }

            intersectionObject.hasHit = true;
            intersectionObject.hitObject = this;
            intersectionObject.ray = ray;
            intersectionObject.hitPoint = ray.origin + (ray.direction * txMin); ;
            intersectionObject.tMin = txMin;
            return intersectionObject;
        }
    }
}