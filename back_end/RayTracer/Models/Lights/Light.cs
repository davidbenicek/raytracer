using System;
using rayTracer.Models.Elements;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Lights
{
    /* By default the light is not ambient, and the difference between
     * and ambient light and other lights will be in the virtual methods,
     * which are mentioned in this class
    */ 

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

        /* This function is responsible for the calculation of the distance between
         * a point that we are currently at ( in other words, the point on the surface)
         * and the position of the light
        */ 
        public virtual double GetDistance(Point3D surfacePoint)
        {
            return position.GetDistance(surfacePoint);
        }

        /*This function will find the direction of the that point on the surface,
         * with respect to the light, by doing the calculations below,
         * and then normalizing the result, this information is needed
         * to create a new ray, to find whether it hits another objects
         * or not, and so it is something related to reflection.
        */ 
        public virtual Vector3D GetDirection(Point3D surfacePoint)
        {
            Vector3D direction = position - surfacePoint;
            direction.Normalize();
            return direction;
        }

        /* This function will be used to get the color of light on the given hitpoint,
         * to determine the color with the intensity of the light, and the distance
         * and the color of that light.
        */ 
        public virtual ColorRGB GetColor(HitInfo hitInfo)
        {
            double distance = 100.0 / position.GetDistance(hitInfo.hitPoint);
            return intensity * rgbColor * distance;
        }
    }
}
