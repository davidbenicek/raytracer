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
        string shape;
        Point3D size;
        Point3D point;
        ColorRGB color;
        string material;

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

        public void SetShape(string matType)
        {
            this.shape = matType;
        }

        public string GetShape()
        {
            return shape;
        }

        public void SetSize(Point3D size)
        {
            this.size = size;
        }

        public Point3D GetSize()
        {
            return size;
        }

        public void SetPoint(Point3D point)
        {
            this.point = point;
        }

        public Point3D GetPoint()
        {
            return point;
        }

        public void SetColor(ColorRGB color)
        {
            this.color = color;
        }

        public ColorRGB GetColor()
        {
            return color;
        }

        public void SetMaterial(string material)
        {
            this.material = material;
        }

        public string GetMaterial()
        {
            return material;
        }
    }
}