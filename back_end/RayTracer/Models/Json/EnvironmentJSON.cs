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

        public void SetWindowFrame(WindowFrame winFrame)
        {
            this.winFrame = winFrame;
        }

        public WindowFrame GetWindowFrame()
        {
            return winFrame;
        }

        public void SetBackground(ColorRGB background)
        {
            this.background = background;
        }

        public ColorRGB GetBackground()
        {
            return background;
        }

        public void SetLights(List<Light> lights)
        {
            this.lights = lights;
        }

        public List<Light> GetLight()
        {
            return lights;
        }

        public void SetCamera(Camera camera)
        {
            this.camera = camera;
        }

        public Camera GetCamera()
        {
            return camera;
        }
    }
}