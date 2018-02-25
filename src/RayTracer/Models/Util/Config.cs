using System.Collections.Generic;
using RayTracer.Models.Elements;
using RayTracer.Models.Materials;

namespace RayTracer.Models.Util
{
    public class Config
    {
        public static ColorRGB WHITE
        {
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

        public static Vector3D DEFAULT_UP_VECTOR
        {
            get
            {
                return new Vector3D(0, 1, 0);
            }
        }

        public static Point3D DEFAULT_POINT
        {
            get
            {
                return new Point3D(0);
            }
        }

        public static string DEFAULT_MATERIAL
        {
            get
            {
                return "flat";
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

        public static double DEFAULT_DISTANCE_VIEW
        {
            get
            {
                return 1.0;
            }
        }

        public static double SHADE_MIN
        {
            get
            {
                return 0.45;
            }
        }

        public static double DEFAULT_INTENSITY
        {
            get
            {
                return 1.0;
            }
        }

        public static Material DEFAULT_MATERIAL_OBJECT
        {
            get
            {
                return new Flat(DEFAULT_COLOR);
            }
        }

        public static Dictionary<string, Material> MATERIALS_DICTIONARY
        {
            get
            {
                Dictionary<string, Material> materials = new Dictionary<string, Material>();
                materials.Add("flat", new Flat());
                materials.Add("chalk", new Chalk());
                materials.Add("metal", new Metal());
                materials.Add("mirror", new Mirror());
                materials.Add("plastic", new Plastic());
                return materials;
            }
        }

        public static double KEPSILON_VALUE
        {
            get
            {
                return 0.00001;
            }
        }

        public static double KEpsilonPlane
        {
            get
            {
                return 0.00001;
            }
        }

        public static int NUM_OF_SETS
        {
            get
            {
                return 5;
            }
        }

        public static int NUM_OF_SAMPLES
        {
            get
            {
                return 5;
            }
        }

        public static double DEFAULT_WALL_POSITION
        {
            get
            {
                return 100.0;
            }
        }
    }
}
