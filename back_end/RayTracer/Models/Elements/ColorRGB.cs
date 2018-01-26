using System;
namespace rayTracer.Models.Elements
{
    public class ColorRGB
    {
        public double r { set; get; }
        public double g { set; get; }
        public double b { set; get; }

        public ColorRGB()
        {
            r = 0.0;
            g = 0.0;
            b = 0.0;
        }

        public ColorRGB(double Value)
        {
            r = Value;
            g = Value;
            b = Value;
        }

        public ColorRGB(ColorRGB colorObj)
        {
            r = colorObj.r;
            g = colorObj.g;
            b = colorObj.b;
        }

        public ColorRGB(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        //This function overload the add operation between two colors and return a new color
        public static ColorRGB operator +(ColorRGB colorA, ColorRGB colorb)
        {
            return new ColorRGB(colorA.r + colorb.r, colorA.g + colorb.g, colorA.b + colorb.b);
        }
        //This function overload the multiply operation between two colors and return a new color
        public static ColorRGB operator *(ColorRGB colorA, ColorRGB colorb)
        {
            return new ColorRGB(colorA.r * colorb.r, colorA.g * colorb.g, colorA.b * colorb.b);
        }
        //This function overload the multiplication of a scale by a color
        public static ColorRGB operator *(double scale, ColorRGB colorA)
        {
            return new ColorRGB(colorA.r * scale, colorA.g * scale, colorA.b * scale);
        }
        //This function overload the multiplication of a color by a scale
        public static ColorRGB operator *(ColorRGB colorA, double scale)
        {
            return new ColorRGB(colorA.r * scale, colorA.g * scale, colorA.b * scale);
        }
        //This function overload the division of a color by a scale
        public static ColorRGB operator /(ColorRGB colorA, double scale)
        {
            return new ColorRGB(colorA.r / scale, colorA.g / scale, colorA.b / scale);
        }
        //This function will calculate the values of r,g,b colors raised to some power value
        public ColorRGB Power(double Factor)
        {
            return new ColorRGB(
                Math.Pow(r, Factor),
                Math.Pow(g, Factor),
                Math.Pow(b, Factor)
            );
        }

    }
}
