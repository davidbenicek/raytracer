using System;
namespace RayTracer.Models.SceneElements
{
    public class WindowFrame
    {
        //The horizontal Resolution
        public int Width { set; get; }
        //The vertical Resolution
        public int Height { set; get; }
        public double PixelSize { set; get; }

        public WindowFrame(int Width, int Height, int PixelSize = 1)
        {
            this.Width = Width;
            this.Height = Height;
            this.PixelSize = PixelSize;
        }
    }
}
