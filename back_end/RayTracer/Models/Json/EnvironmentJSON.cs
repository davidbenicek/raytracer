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
        Light light;
        Camera camera;

        public EnvironmentJSON(string fileName, WindowFrame winFrame, ColorRGB background, Light light, Camera camera)
        {
            this.fileName = fileName;
            this.winFrame = winFrame;
            this.background = background;
            this.light = light;
            this.camera = camera;
        }

        public void setFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public string getFileName()
        {
            return fileName;
        }

        public void setWinFrame(WindowFrame winFrame)
        {
            this.winFrame = winFrame;
        }

        public WindowFrame getWinFrame()
        {
            return winFrame;
        }

        public void setBackground(ColorRGB background)
        {
            this.background = background;
        }

        public ColorRGB getBackground()
        {
            return background;
        }

        public void setLight(Light light)
        {
            this.light = light;
        }

        public Light getLight()
        {
            return light;
        }

        public void setCamera(Camera camera)
        {
            this.camera = camera;
        }

        public Camera GetCamera()
        {
            return camera;
        }
        
    }
}