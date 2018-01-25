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

        public Scene(WindowFrame winFrame, Camera camera)
        {
            this.lightsList = new List<Light>();
            this.objectsList = new List<GeometryObject>();
            this.finalPixels = new ColorRGB[winFrame.Width * winFrame.Height];
            this.winFrame = winFrame;
            background = Config.DEFAULT_COLOR;
            this.camera = camera;
        }

        public Scene(Scene sceneObj)
        {
            lightsList = new List<Light>();
            lightsList.AddRange(sceneObj.lightsList);

            objectsList = new List<GeometryObject>();
            objectsList.AddRange(sceneObj.objectsList);

            if (sceneObj.background != null)
            {
                background = new ColorRGB(sceneObj.GetBackgroundColor());
            }

            winFrame = sceneObj.winFrame;

            finalPixels = new ColorRGB[winFrame.Width * winFrame.Height];
        }

        public Scene(List<Light> Lights, List<GeometryObject> objectsList, ColorRGB Background, WindowFrame winFrame, Camera camera)
        {
            lightsList = new List<Light>();
            Lights.AddRange(Lights);

            objectsList = new List<GeometryObject>();
            objectsList.AddRange(objectsList);
            background = new ColorRGB(Background);
            this.winFrame = winFrame;
            finalPixels = new ColorRGB[winFrame.Width * winFrame.Height];
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
    }
}
