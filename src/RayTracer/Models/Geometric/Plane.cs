using System;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Geometric
{
    public class Plane: GeometryObject
    {
        Point3D point;
        Vector3D normal;
        public static double kEpsilon = Config.KEpsilonPlane;

        public Plane()
        {
            point = new Point3D();
            normal = new Vector3D();
        }

        public Plane(Plane PlaneObj)
        {
            point = new Point3D(PlaneObj.point);
            normal = new Vector3D(PlaneObj.normal);
        }

        public Plane(Point3D point, Vector3D normal)
        {
            this.point = point;
            this.normal = normal;
        }

        /* THis method will check if the ray is hitting the plane,
         * by checking if the hit point is inside or outside the plane itself,
         * It will compare the value with some predefined epsilon which is very
         * small value that is configured in the configuration class
         * then it will return the hit information so that they can be used
         * by other class which are depending on this method such as the render.
        */ 

        public override HitInfo Intersect(Ray ray)
        {
            try
            {
                /* We need to find the t Value, which will be substituted in this equation:
                 * HitPoint = origin + RayDirection * t
                 * And so find the hitpoint.
                 */

                double denom = ray.direction.DotProduct(normal);
                HitInfo hitInfo = new HitInfo();
                hitInfo.hasHit = false;

                /* This will check if the denominator less than zero so don't do the calculations
                 * and just return false; since it will lead to division by zero exception 
                 * if that is not checked.
                */ 
                if (denom.Equals(0))
                {
                    return hitInfo;
                }

                double t = (point - ray.origin).DotProduct(normal) / denom;

                /* Check if the value of t is greater than the threshold, 
                 * if it is not, then just return flase,
                 * Else, adding the value of t to TMin, and return the HitPoint
                 * and Return true.
                 */
                if (t > kEpsilon)
                {
                    hitInfo.tMin = t;
                    hitInfo.normalAtHit = normal;
                    hitInfo.hitPoint = ray.origin + (ray.direction * t);
                    hitInfo.hasHit = true;
                    hitInfo.hitObject = this;
                    hitInfo.ray.origin = ray.origin;
                    hitInfo.ray.direction = ray.direction;
                    return hitInfo;
                }

                return hitInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }
    }
}
