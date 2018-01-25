using System;
using rayTracer.Models.Elements;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Lights
{
    public class Light
    {
        protected double intensity;
        protected ColorRGB rgbColor;
        protected Point3D position;

        public Light()
        {

        }

        public Light(Point3D Position, ColorRGB RGBColor, double intensity)
        {
            this.position = Position;
            this.intensity = intensity;
            this.rgbColor = RGBColor;
        }

        public Light(Light LightObj)
        {
            this.intensity = LightObj.intensity;
            this.rgbColor = LightObj.rgbColor;
        }

    }
}
