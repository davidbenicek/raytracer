using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    /* This a material which will follow the Phong model,
     * but the values of the coefficient is the difference
     * between it and the other materials.
    */ 
    public class Chalk: Phong
    {
        public Chalk()
            :base(Config.DEFAULT_COLOR, 0.4, 0.2, 2, 0.25 )
        {
            
        }

        public Chalk(ColorRGB rgbColor, double diffusionCoeff = 0.4, double specularCoeff = 0.2, double specular = 2, double lightColorInf = 0.25)
            : base(rgbColor, diffusionCoeff, specularCoeff, specular, lightColorInf)
        {

        }
    }
}
