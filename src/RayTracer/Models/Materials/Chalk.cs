using System;
using rayTracer.Models.Elements;

namespace RayTracer.Models.Materials
{
    /* This a material which will follow the Phong model,
     * but the values of the coefficient is the difference
     * between it and the other materials.
    */ 
    public class Chalk: Phong
    {
        public Chalk()
        {

        }

        public Chalk(ColorRGB rgbColor, double diffusionCoeff = 0.4, double specularCoeff = 0.2, double specular = 2, double lightColorInf = 0.25)
            : base(rgbColor, diffusionCoeff, specularCoeff, specular, lightColorInf)
        {

        }
    }
}
