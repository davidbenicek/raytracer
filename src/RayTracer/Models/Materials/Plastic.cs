using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    public class Plastic: Phong
    {
        public Plastic()
            :base(Config.DEFAULT_COLOR, 0.4,0.2,20, 0.35)
        {
            
        }

        public Plastic(ColorRGB rgbColor, double diffusionCoeff = 0.4, double specularCoeff = 0.2, double specular = 20, double lightColorInf = 0.35)
            : base(rgbColor, diffusionCoeff, specularCoeff, specular, lightColorInf)
        {

        }
    }
}
