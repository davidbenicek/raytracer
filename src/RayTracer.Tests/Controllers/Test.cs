using NUnit.Framework;
using RayTracer.

namespace RayTracer.Tests.Controllers
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestCase()
        {
            Scene scene = new Scene(new WindowFrame(2000, 2000, 1.0));
            scene.SetFileName("test");
            scene.CreateScene();
            scene.Render();
        }
    }
}
