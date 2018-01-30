using NUnit.Framework;
using System;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Cameras;
using RayTracer.Models.Elements;

namespace RayTracer.Test
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            WindowFrame winFrame = new WindowFrame(800, 600);
            Scene scene = new Scene(winFrame, new Perspective(new Point3D(0, 0, 500), new Point3D(-5, 0, 0), 850));

            scene.CreateScene();
            scene.Render();
            scene.FinalPicture();

            Assert.IsTrue(true);
        }
    }
}
