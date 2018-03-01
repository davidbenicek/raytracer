using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Elements;
using System.IO;

namespace RayTracer.UnitTests
{
    [TestClass]
    public class SceneTests
    {
        [TestMethod()]
        public void TestFinalPicture()
        {
            Scene scene = new Scene(new WindowFrame(2000, 2000, 1.0));
            scene.SetFileName("bitmapPic");
            scene.CreateScene();
            scene.Render();
            Assert.IsTrue(File.Exists(@"C:\Users\nargv\source\repos\raytracer\back_end\RayTracer.Tests\bitmapPic.jpg"));
        }

        public bool Exists(string path)
        {
            if (File.Exists(path)) return true;
            else return false;
        }
        // DisplayPixel() doesn't return anything so ns how to test

        [TestMethod()]
        public void TestGetHitInfo()
        {

        }

        [TestMethod()]
        public void TestDisplayPixel()
        {
            Scene scene = new Scene(new WindowFrame(2000, 2000, 1.0), null, new ColorRGB(), null);
            ColorRGB color = new ColorRGB(1.0, 1.0, 1.0);
            scene.DisplayPixel(1, 1, color);
            scene.GetFinalPixels();

            Assert.IsTrue(scene.GetFinalPixels() == scene.DisplayPixel(1, 1, color));
        }
    }
}