using rayTracer.Models.Elements;
using RayTracer.Models.Cameras;
using RayTracer.Models.Lights;
using RayTracer.Models.SceneElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RayTracer.Models.Json
{
    public class EnvironmentJSON
    {
        string fileName;
        WindowFrame winFrame;
        ColorRGB background;
        List<Light> lights;
        Camera camera;

        public EnvironmentJSON(string fileName, WindowFrame winFrame, ColorRGB background, List<Light> lights, Camera camera)
        {
            this.fileName = fileName;
            this.winFrame = winFrame;
            this.background = background;
            this.lights = lights;
            this.camera = camera;
        }

        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public string GetFileName()
        {
            return fileName;
        }
    }
}