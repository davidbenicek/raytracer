using System;
using System.Collections.Generic;
using rayTracer.Models.Elements;
using RayTracer.Models.Cameras;
using RayTracer.Models.Lights;
using RayTracer.Models.Geometric;
using RayTracer.Models.Util;

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
    }
}
