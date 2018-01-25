using System;
using rayTracer.Models.Elements;
using RayTracer.Models.Elements;

namespace RayTracer.Models.Util
{
    public class Config
    {
        public static ColorRGB WHITE{
            get
            {
                return new ColorRGB(1);
            }
        }

        public static ColorRGB DEFAULT_COLOR
        {
            get
            {
                return new ColorRGB(0);
            }
        }

        public static Vector3D DEFAULT_VECTOR
        {
            get
            {
                return new Vector3D(0);
            }
        }

        public static Point3D DEFAULT_POINT
        {
            get
            {
                return new Point3D(0);
            }
        }

        public static double AMBIENT_COEFF
        {
            get
            {
                return 0.2;
            }
        }

        public static double DEFAULT_RADIUS
        {
            get
            {
                return 1.0;
            }
        }

    }
}
