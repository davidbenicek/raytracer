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
        public string fileName;
        public WindowFrame winFrame;
        public ColorRGB background;
        public List<Light> lights;
        public Perspective camera;

        public EnvironmentJSON(string fileName, WindowFrame winFrame, ColorRGB background, List<Light> lights, Perspective camera)
        {
            this.fileName = fileName;
            this.winFrame = winFrame;
            this.background = background;
            this.lights = lights;
            this.camera = new Perspective(camera);
        }
    }
}