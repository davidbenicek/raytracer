using System;
using System.Collections.Generic;
using rayTracer.Models.Elements;
using RayTracer.Models.Elements;
using RayTracer.Models.Lights;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Materials
{
    public class Phong : Material
    {
        public Phong()
        {
            
        }

        public Phong(ColorRGB rgbColor, double diffusionCoeff, double specularCoeff, double specular, double lightColorInf)
            : base(rgbColor, diffusionCoeff, specularCoeff, specular, lightColorInf)
        {

        }

        /* This method will calculate the shade based on Phong shading model,
         * the calculations which were done here are based on that model.
         * In this method, we are calcuation the diffusion value, specular value,
         * based on the lights in the scene, and 
         * the effect of the ambient light on the final color.
        */ 
        public override ColorRGB CalculateShade(HitInfo hitInfo, Scene scene = null)
        {
            Vector3D vector = -hitInfo.ray.direction;

            Vector3D normal = hitInfo.normalAtHit;

            ColorRGB diffuseValue = new ColorRGB(0);
            ColorRGB specularValue = new ColorRGB(0);

            if (scene.GetLights() != null && scene.GetLights().Count > 0)
            {
                foreach (Light light in scene.GetLights())
                {
                    ColorRGB lightColor = light.GetColor(hitInfo);
                    Vector3D lightDirection = light.GetDirection(hitInfo.hitPoint);

                    Vector3D R = 2.0 * (lightDirection.DotProduct(normal) * normal) - lightDirection;

                    diffuseValue += diffusionCoeff 
                        * (double)Utility.Max((double)lightDirection.DotProduct(normal), 0.0) 
                                         * (lightColor * lightColorInf + (1.0 - lightColorInf) * hitInfo.hitObject.GetMaterial().rgbColor);
                    
                    specularValue += specularCoeff 
                        * Math.Pow((double)Utility.Max((double)R.DotProduct(vector), 0.0), specular) 
                        *(lightColor * lightColorInf + (1.0 - lightColorInf) * hitInfo.hitObject.GetMaterial().rgbColor);
                }
            }

            if (scene.GetAmbientLight() == null)
            {
                AmbientLight ambient_ptr = new AmbientLight(new ColorRGB(.3, .3, .3), 1);
                scene.SetAmbientLight(ambient_ptr);
            }

            ColorRGB ambient = ambientCoeff * (lightColorInf * scene.GetAmbientLight().GetColor(hitInfo) + (1.0 - lightColorInf) * hitInfo.hitObject.GetMaterial().rgbColor);
            return (ambient + diffuseValue + specularValue);
        }
    }
}
