using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Lights
{
    /*In this class, the difference from the other types of lights,
     * is in the implementation of different methods, but GetDistance and 
     * GetDirection will do nothing, and just return 0 and default vector,
     * but the calculation of the color will be just the intensity * color
     * without having a distance, since it is 0, and it is the ambient light
    */ 
    public class AmbientLight: Light
    {
        /* For an ambient light we don't need to do the calculations
         * that are done on other lights, but we need to override
         * the method to return 0, and do nothing for object
         * oriented issues, and inheritance issues
        */

        public AmbientLight(ColorRGB rgbColor, double intensity)
        {
            this.intensity = intensity;
            this.rgbColor = rgbColor;
        }

        public override double GetDistance(Point3D surfacePoint)
        {
            return 0;
        }

        public override Vector3D GetDirection(Point3D surfacePoint)
        {
            return Config.DEFAULT_VECTOR;
        }

        /* This function will be used to get the color of light
         * in general, not for a given hit point; since it is ambient.
        */
        public override ColorRGB GetColor(HitInfo hitInfo = null)
        {
            return intensity * rgbColor;
        }
    }
}
