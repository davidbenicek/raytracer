using System.Collections.Generic;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    public class Mirror : Material
    {
        public Mirror()
            :base(Config.WHITE, 1.0,0.5,1,0.01)
        {
            
        }

        public Mirror(ColorRGB rgbColor, double diffusionCoeff = 1.0, double specularCoeff = 0.5, double specular = 1, double lightColorInf = 0.01)
            : base(rgbColor, diffusionCoeff, specularCoeff, specular, lightColorInf)
        {

        }

        /*This will calculate the shade value by checking if there is a shade
         * caused by another object, and any object checked will be added to the ignore
         * list, so it won't be tested again
        */ 
        public override ColorRGB CalculateShade(HitInfo hitInfo, Scene scene = null)
        {
            Vector3D hitRayDirection = -hitInfo.ray.direction;
            Vector3D normalAtHit = hitInfo.normalAtHit;

            Vector3D vectorResult = (2 * (hitRayDirection.DotProduct(normalAtHit) * normalAtHit)) - hitRayDirection;

            List<GeometryObject> ignore_self = new List<GeometryObject>();

            ignore_self.Add(hitInfo.hitObject);

            /* Create a new ray, with an origin of the hit point,
             * and direction which was calculated in vectorResult
            */ 
            Ray reflected_ray = new Ray(hitInfo.hitPoint, vectorResult);

            ColorRGB base_reflected_color = scene.GetTracer().TraceRay(reflected_ray, ignore_self);

            if (!hitInfo.hasHit)
            {
                return scene.GetBackgroundColor();
            }

            return base_reflected_color;
        }
    }
}
