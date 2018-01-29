using System;
using System.Collections.Generic;
using rayTracer.Models.Elements;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Lights;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Tracing
{
    public class Tracer
    {
        protected Scene scene;

        public Tracer()
        {

        }

        public Tracer(Scene scene)
        {
            this.scene = scene;
        }

        public virtual ColorRGB TraceRay(Ray ray, List<GeometryObject> ignoreObjects = null)
        {
            HitInfo hitDetails = scene.GetHitInfo(ray, ignoreObjects);
            hitDetails.ray = ray;

            if (hitDetails != null && hitDetails.hasHit)
            {
                return hitDetails.hitObject.GetMaterial().CalculateShadow(hitDetails) * TraceShadeRay(hitDetails);
            }
            else
            {
                return scene.GetBackgroundColor();
            }   
        }

        /* This will check, if the shade from the hitting point, and in the direction
         * of the light will hit another object (be on the another object) or not.
         * The check will be done on each object not in ignore list.
        */ 
        private double TraceShadeRay(HitInfo shadeHitInfo)
        {
            double shadeMin = Config.SHADE_MIN;

            /* This will count the number of lights in which it
             * caused a shadow that hits another objects, and has a distance
             * less than the distance of the light itself.
            */ 
            int numberOfShadingLights = 0;

            foreach (Light light in scene.GetLights())
            {
                //This value will be the value of the hitpoint of the calling object.
                Point3D rayOrigin = shadeHitInfo.hitPoint;
                //The direction of the light we are currently testing.
                Vector3D rayDirection = light.GetDirection(rayOrigin);
                Ray ray = new Ray(rayOrigin, rayDirection);
                List<GeometryObject> ignore = new List<GeometryObject>();
                ignore.Add(shadeHitInfo.hitObject);

                HitInfo shadeInfo = scene.GetHitInfo(ray, ignore);

                /* Check if the ray from the origin of the ray which is the hitting point on the calling object
                 * and in the lights direction hits another object
                 * and if yes, is the distance between the hit point 
                 * of the shade on the other object is less than the distance between
                 * the light's position and the hit point on the reference object, then add the number
                 * of the lights that are shadowing on other objects.
                */ 
                if (shadeInfo.hasHit && (rayOrigin.GetDistance(shadeInfo.hitPoint) < light.GetDistance(rayOrigin)))
                {
                    ++numberOfShadingLights;
                }
            }
            /* In this one, we can get the number of lights, that doesn't interesect with any of other objects
             * by subtracting the number of shading lights from the total number of lights
            */ 
            double iluminatedByLights = scene.GetLights().Count - numberOfShadingLights;
            double lightRatio = (iluminatedByLights / scene.GetLights().Count);
            /* Now if no light is shading then just return 1, which will not affect the final color
             * since the value returned from here will be multiplied by the color calculated depending on 
             * the material. Else, it will add the ratio we got, with the predefined minimum value
            */ 
            return (numberOfShadingLights > 0) ? lightRatio + shadeMin : 1.0;
        }

    }
}
