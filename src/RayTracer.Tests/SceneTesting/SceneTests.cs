using RayTracer.Models.SceneElements;
using RayTracer.Models.Elements;
using System.IO;
using NUnit.Framework;
using RayTracer.Models.Util;

namespace RayTracer.Tests.SceneTesting
{
    [TestFixture]
    public class SceneTests
    {
        [Test]
        public void TestFinalPicture()
        {
            Scene scene = new Scene(new WindowFrame(500, 500, 1.0));
            scene.SetFileName("bitmapPic");
            scene.CreateScene();
            scene.Render();
            Assert.IsTrue(File.Exists(@"./bitmapPic.jpg"));
        }

        [Test]
        public void TestGetHitInfo()
        {
            //To be implemented
        }

        [Test]
        public void TestDisplayPixel_Valid_Color_White()
        {
            Scene scene = new Scene(new WindowFrame(2000, 2000, 1.0), null, new ColorRGB(), null);
            ColorRGB color = new ColorRGB(1.0, 1.0, 1.0);
            scene.DisplayPixel(1, 1, color);
            ColorRGB [, ]finalPixel = scene.GetFinalPixels();

            Assert.IsTrue(finalPixel[1,1].Equals(color));
        }

        [Test]
        public void TestDisplayPixel_InValid_Color()
        {
            Scene scene = new Scene(new WindowFrame(2000, 2000, 1.0), null, new ColorRGB(), null);
            ColorRGB color = new ColorRGB(1.5, 1.5, 1.5);
            scene.DisplayPixel(1, 1, color);
            ColorRGB[,] finalPixel = scene.GetFinalPixels();

            Assert.IsTrue(finalPixel[1, 1].Equals(Config.WHITE));
        }

        [Test]
        public void TestDisplayPixel_Valid_Color_Minimum_Black()
        {
            Scene scene = new Scene(new WindowFrame(2000, 2000, 1.0), null, new ColorRGB(), null);
            ColorRGB color = new ColorRGB(0);
            scene.DisplayPixel(1, 1, color);
            ColorRGB[,] finalPixel = scene.GetFinalPixels();

            Assert.IsTrue(finalPixel[1, 1].Equals(color));
        }
    }
}