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
            HitInfo intersectionObject= new HitInfo();
            double t;
            //return Hitinfo details if true and the ray hits an object
            /* In this function we need to solve a quadratic equation, to find the closest point
            * which hits the sphere, the equation is in this format
            * a* x^2 + b * x + c
            * where 
            * 1. a = the dot product of vector's direction by itself
            * 2. b = The dot product of (2 * (origin - center of the sphere)) and vector's direction 
            * 3. c = The value of Radius ^ 2 subtracted from the dot product of (origin - center) by itself
            * based on the solution we can find the value of the TMin which is the value of shift needed
            * until reaching the hit point on the object. */

            Vector3D tempVector = ray.origin - center;
            //The factor of x^2 in the equation.
            double a =ray.direction.DotProduct(ray.direction);
            //The factor of x in the equation.
            double b = 2 * (tempVector.DotProduct(ray.direction));
            //The constant C in the equation.
            double c = tempVector.DotProduct(tempVector) - (radius* radius);

            double discriminant = (b * b) - (4 * a * c);
            //if the discriminant is less than 0, it means there is no real solution for the equation
            //meaning the ray does not intersect at any point on the surface of the sphere

            if(discriminant<0.0)
            {
                intersectionObject.hasHit = false;
                return intersectionObject;
            }

            double discSqrt = Math.Sqrt(discriminant);
            double denominator = 2 * a;

            //check if denominator is equal to zero
            if(denominator==0.0)
            {
                intersectionObject.hasHit = false;
                return intersectionObject;
            }
            //We check for -b-sqrt(b^2-4ac)/2a
            /*We need to check if the value of the smaller rootis smaller than a given threshold value*/
            t = ((-1 * b) - discSqrt) / denominator;

            if(t>Config.KEPSILON_VALUE)
            {
                intersectionObject.hasHit = true;
                intersectionObject.tMin = t;
                intersectionObject.hitObject = this;
                intersectionObject.ray = ray;
                //This represents the point where the ray hits the object
                intersectionObject.hitPoint = ray.origin + (ray.direction * t);
                //Check
                intersectionObject.normalAtHit = (tempVector + (ray.direction)) / radius;
                return intersectionObject;
            }

            //Next We check for -b-sqrt(b^2-4ac)/2a
            /*If the value of the smaller root fails the comparison above,
             * Then we need to check if the value of the  bigger root satisfies this criteria 
             * as well*/
            t = ((-1 * b) + discSqrt) / denominator;

            if (t > Config.KEPSILON_VALUE)
            {
                intersectionObject.hasHit = true;
                intersectionObject.tMin = t;
                intersectionObject.hitObject = this;
                intersectionObject.ray = ray;
                //This represents the point where the ray hits the object
                intersectionObject.hitPoint = ray.origin + (ray.direction * t);
                //Check
                intersectionObject.normalAtHit = (tempVector + (ray.direction)) / radius;
                return intersectionObject;
            }

            /*If there is no solution greater than the threshold, then this ray didn't hit
                 * the sphere and so it will return false
                 */
            intersectionObject.hasHit = false;
            return intersectionObject;

        }
    }
}
