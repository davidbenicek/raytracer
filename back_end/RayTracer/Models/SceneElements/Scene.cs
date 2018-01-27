using System;
using System.Collections.Generic;
using rayTracer.Models.Elements;
using RayTracer.Models.Cameras;
using RayTracer.Models.Lights;
using RayTracer.Models.Geometric;
using RayTracer.Models.Util;
using RayTracer.Models.Elements;

namespace RayTracer.Models.SceneElements
{
    public class Scene
    {
        List<Light> lightsList;
        List<GeometryObject> objectsList;
        ColorRGB background;
        WindowFrame winFrame;
        ColorRGB[] finalPixels;
        Camera camera;
        Light ambientLight;

        public Scene(WindowFrame winFrame, Camera camera)
        {
            this.lightsList = new List<Light>();
            this.objectsList = new List<GeometryObject>();
            this.finalPixels = new ColorRGB[winFrame.width * winFrame.height];
            this.winFrame = winFrame;
            background = Config.DEFAULT_COLOR;
            this.camera = camera;
        }

        public Scene(Scene sceneObj)
        {
            SetLights(sceneObj.lightsList);
            SetObjects(sceneObj.objectsList);

            if (sceneObj.background != null)
            {
                background = new ColorRGB(sceneObj.GetBackgroundColor());
            }

            winFrame = sceneObj.winFrame;

            finalPixels = new ColorRGB[winFrame.width * winFrame.height];
        }

        public Scene(List<Light> lights, List<GeometryObject> objectsList, ColorRGB Background, WindowFrame winFrame, Camera camera)
        {
            SetLights(lights);
            SetObjects(objectsList);
            background = new ColorRGB(Background);
            this.winFrame = winFrame;
            finalPixels = new ColorRGB[winFrame.width * winFrame.height];
            this.camera = camera;
        }

        public void AddObject(GeometryObject geoObj)
        {
            objectsList.Add(geoObj);
        }

        public void AddLight(Light lightObj)
        {
            lightsList.Add(lightObj);
        }

        public ColorRGB GetBackgroundColor()
        {
            return background;
        }

        public void SetLights(List<Light> lights)
        {
            lightsList = new List<Light>();
            lightsList.AddRange(lights);
        }

        public void SetObjects(List<GeometryObject> objects)
        {
            objectsList = new List<GeometryObject>();
            objectsList.AddRange(objectsList);
        }

        public List<Light> GetLights()
        {
            return lightsList;
        }

        public List<GeometryObject> GetObjects()
        {
            return objectsList;
        }

        public ColorRGB[] GetFinalPixels()
        {
            return finalPixels;
        }

        public void SetAmbientLight(Light ambientLight)
        {
            this.ambientLight = (AmbientLight)ambientLight;
        }

        public Light GetAmbientLight()
        {
            return ambientLight;
        }

        /* In this method, we will loop over the whole objects in the scene,
         * to check which object did the ray hit, also, we if there are 
         * many objects which were hit by the ray, return the closest one
         * of theses objects in a an object called HitInfo, also check, if 
         * this object is in the ignore objects, and if it is there, so don't do
         * anything on that object
        */
        public HitInfo GetHitInfo(Ray ray, List<GeometryObject> ignoreObjects = null)
        {
            try
            {
                /* Create an object of hitInfo, and assign a value to it's tMin,
                 * to be the maximum possible of a double, to check that 
                 * with the values returned from the loop over objects
                */

                HitInfo hitInfo = new HitInfo();
                hitInfo.tMin = double.MaxValue;

                foreach (GeometryObject geoObj in objectsList)
                {
                    /* Check if the geoObj is in the ignore list of objects and so
                     * if it is there then just continue and do nothing
                     */
                    if (ignoreObjects != null && ignoreObjects.Contains(geoObj))
                    {
                        continue;
                    }

                    HitInfo intersectInfo = geoObj.Intersect(ray);
                    /* If the ray didn't hit the object, then just continue,
                     * and ignore that object, else check the hit info with the current ones
                     * to check if it is smaller than the current, and so take them,
                     * this will be based on the tMin value
                    */
                    if (!intersectInfo.hasHit)
                    {
                        continue;
                    }

                    if (intersectInfo.tMin < hitInfo.tMin)
                    {
                        hitInfo = new HitInfo(intersectInfo);
                    }
                }

                return hitInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
