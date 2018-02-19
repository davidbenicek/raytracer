using RayTracer.Models.Elements;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    public abstract class Material
    {
        public double diffusionCoeff;
        public double specularCoeff;
        public double specular;
        public double lightColorInf;
        public double ambientCoeff = Config.AMBIENT_COEFF;
        public ColorRGB rgbColor = Config.WHITE;

        public Material()
        {

        }

        public Material(ColorRGB rgbColor)
        {
            SetColor(rgbColor);
        }

        public Material(ColorRGB rgbColor, double diffusionCoeff, double specularCoeff, double specular, double lightColorInf)
        {
            SetColor(rgbColor);
            this.diffusionCoeff = diffusionCoeff;
            this.specularCoeff = specularCoeff;
            this.specular = specular;
            this.lightColorInf = lightColorInf;
        }

        public Material(Material material)
        {
            SetColor(material.rgbColor);
            diffusionCoeff = material.diffusionCoeff;
            specular = material.specular;
            lightColorInf = material.lightColorInf;
            ambientCoeff = material.ambientCoeff;
            rgbColor = material.rgbColor;
        }

        public void SetColor(ColorRGB rgbColor)
        {
            if (rgbColor != null)
            {
                this.rgbColor = rgbColor;
            }
            else
            {
                this.rgbColor = Config.DEFAULT_COLOR;
            }
        }

        /* In this function we'll calculate the shade of the object,
         * but it depends on the material, and the values of different
         * coefficients provided with each material.
        */ 
        public abstract ColorRGB CalculateShade(HitInfo hitInfo, Scene scene = null);

    }
}
