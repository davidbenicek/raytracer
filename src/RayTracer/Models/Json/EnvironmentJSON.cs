using RayTracer.Models.Elements;
using RayTracer.Models.Cameras;
using RayTracer.Models.Lights;
using RayTracer.Models.SceneElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RayTracer.Models.Util;

namespace RayTracer.Models.Json
{
    public class EnvironmentJSON
    {
        public string fileName;
        public WindowFrame winFrame;
        public ColorRGB background;
        public List<Light> lights;
        public Perspective camera;
        public double wallPosition;

        public EnvironmentJSON(string fileName, WindowFrame winFrame, ColorRGB background, List<Light> lights, Perspective camera, double wallPosition)
        {
            this.fileName = fileName;
            this.winFrame = winFrame;
            this.background = background;
            this.lights = lights;
            this.camera = new Perspective(camera);
            this.wallPosition = wallPosition;
            if(wallPosition.Equals(0.0))
            {
                wallPosition = Config.DEFAULT_WALL_POSITION;
            }
            this.wallPosition = wallPosition;
        }
    }
}