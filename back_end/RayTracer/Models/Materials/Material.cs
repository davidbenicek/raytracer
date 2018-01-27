using System;
using rayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    public class Material
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
        }

    }
}
