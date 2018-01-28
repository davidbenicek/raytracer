using System;
using rayTracer.Models.Elements;

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
    }
}
