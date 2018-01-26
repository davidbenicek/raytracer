using System;
using rayTracer.Models.Elements;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Lights
{
    public class Light
    {
        public double intensity = Config.DEFAULT_INTENSITY;
        public ColorRGB rgbColor;
        public Point3D position;

        public Light()
        {

        }

        public Light(Point3D Position, ColorRGB RGBColor)
        {
            this.position = Position;
            this.rgbColor = RGBColor;
        }

        public Light(Point3D Position, ColorRGB RGBColor, double intensity)
        {
            this.position = Position;
            this.rgbColor = RGBColor;
            this.intensity = intensity;
        }

        public Light(Light LightObj)
        {
            this.intensity = LightObj.intensity;
            this.rgbColor = LightObj.rgbColor;
            this.position = LightObj.position;

        }

    }
}
