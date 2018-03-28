using NUnit.Framework;
using RayTracer.Models.SceneElements;

namespace RayTracer.Tests.Controllers
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestCase()
        {
            Scene scene = new Scene(new WindowFrame(500, 500, 1.0));
            scene.SetFileName("test");
            scene.CreateScene();
            scene.Render();

            scene.FinalPicture();
        }
    }
}
