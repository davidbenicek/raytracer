using System;
namespace RayTracer.Models.Util
{
    public class Utility
    {
        public static double Clamp(double LO, double HI, double V)
        {
            return Max(LO, Math.Min(HI, V));
        }

        public static double Max(double a, double b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }
    }
}
