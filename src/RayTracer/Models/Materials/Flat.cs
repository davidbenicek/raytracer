using rayTracer.Models.Elements;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    public class Flat : Material
    {
        public Flat()
            : base()
        {

        }

        public Flat(ColorRGB RGBColor)
            : base(RGBColor)
        {

        }

        /* In this type of materials, the light won't affect it 
         * since it is metal, and so just return the color 
         * of that material, without any further calculations,
         * In other way there is no reflections, refractions, ... etc
         * and so the shade of this object will be it's color.
        */ 
        public override ColorRGB CalculateShade(HitInfo hitInfo, Scene scene = null)
        {
            return rgbColor;
        }
    }
}
