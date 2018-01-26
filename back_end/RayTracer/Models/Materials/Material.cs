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
        public ColorRGB rgbColor;

        public Material()
        {
            this.rgbColor = Config.WHITE;
        }

        public Material(ColorRGB rgbColor)
        {
            if (rgbColor == null)
            {
                this.rgbColor = Config.WHITE;
            }
            else
            {
                this.rgbColor = rgbColor;
            }
        }

        public Material(ColorRGB rgbColor, double diffusionCoeff, double specularCoeff, double specular, double lightColorInf)
        {
            if (rgbColor == null)
            {
                rgbColor = Config.WHITE;
            }

            this.rgbColor = rgbColor;
            this.diffusionCoeff = diffusionCoeff;
            this.specularCoeff = specularCoeff;
            this.specular = specular;
            this.lightColorInf = lightColorInf;
        }

        public Material(Material Material)
        {
            rgbColor = Material.rgbColor;
        }

    }
}
