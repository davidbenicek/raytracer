using rayTracer.Models.Elements;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RayTracer.Models.Json
{
    public class GeometryJSON
    {
        public string shape;
        public Point3D size;
        public Point3D point;
        public ColorRGB color;
        public string material;

        public GeometryJSON(string shape, Point3D size, Point3D point, ColorRGB color = null, string material = null)
        {
            this.shape = shape;
            this.size = size;
            this.point = point;
            if (color == null)
            {
                this.color = Config.DEFAULT_COLOR;
            }
            else
            {
                this.color = color;
            }
            if(material == null)
            {
                this.material = Config.DEFAULT_MATERIAL;
            }
            else
            {
                this.material = material;
            }
            this.shape = shape;
        }
    }
}