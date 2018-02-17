using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    public class Metal: Phong
    {
        public Metal()
            :base(Config.DEFAULT_COLOR, 0.4,0.2,100, 0.001)
        {
            
        }
        
        public Metal(ColorRGB rgbColor, double diffusionCoeff = 0.4, double specularCoeff = 0.2, double specular = 100, double lightColorInf = 0.001)
            : base(rgbColor, diffusionCoeff, specularCoeff, specular, lightColorInf)
        {

        }
    }
}
