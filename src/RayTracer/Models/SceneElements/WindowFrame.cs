using System;
namespace RayTracer.Models.SceneElements
{
    public class WindowFrame
    {
        //The horizontal Resolution
        public int width;
        //The vertical Resolution
        public int height;

        public double pixelSize;

        public WindowFrame(int width, int height, double pixelSize = 1)
        {
            this.width = width;
            this.height = height;
            this.pixelSize = pixelSize;
        }
    }
}
