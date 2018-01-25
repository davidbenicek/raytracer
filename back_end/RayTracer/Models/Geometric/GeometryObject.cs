using System;
using RayTracer.Models.Elements;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Models.Geometric
{
    public abstract class GeometryObject
    {
        protected Material material { set; get; }

        public GeometryObject()
        {

        }

        public GeometryObject(Material material)
        {
            this.material = material;
        }

        public void SetMaterial(Material material)
        {
            this.material = material;
        }

        public Material GetMaterial()
        {
            return material;
        }

        public abstract HitInfo Intersect(Ray ray);
    }
}
