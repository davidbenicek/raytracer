using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Lights;
using RayTracer.Models.Materials;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Tracing;
using RayTracer.Models.Util;
using RayTracer.Tests.SceneTesting;

namespace RayTracer.Tests.MaterialsTesting
{
    [TestFixture]
    public class MirrorTest
    {
        WindowFrame winFrame;
        HitInfo hitInfo;

        [TestFixtureSetUp]
        public void Init()
        {
            winFrame = new WindowFrame(2000, 2000);
            hitInfo = new HitInfo();
            hitInfo.hitObject = new Sphere(new Point3D(-50, 0, 60), 30, new Metal(new ColorRGB(1, 0, 0)));
            hitInfo.hitPoint = new Point3D(1);
            Vector3D rayDirection = new Vector3D(-0.6, -0.8, -0.99);
            Point3D rayOrigin = new Point3D(0, 30, 300);
            Ray testRay = new Ray(rayOrigin, rayDirection);
            hitInfo.ray = testRay;        }

        [Test]
        public void TestCalculateShade_HasHitFalse()
        {
            //Arrange
            Scene scene = new Scene(winFrame);
            Mirror mirror = new Mirror();
            hitInfo.hasHit = false;
            //Act
            ColorRGB color = mirror.CalculateShade(hitInfo, scene);
            //Assert
            Assert.IsTrue(color.Equals(scene.GetBackgroundColor()));
        }
        //This method assumes that the color of the object is different than scene's background
        [Test]
        public void TestCalculateShade_HasHitTrue()
        {
            //Arrange
            SceneTestInstance sceneTestInstance = new SceneTestInstance(winFrame);
            sceneTestInstance.SetValue(2);

            Point3D lightPos = new Point3D(100);
            ColorRGB lightColor = new ColorRGB(1, 0, 0);
            sceneTestInstance.AddLight(new Light(lightPos, lightColor));

            Point3D testPoint = new Point3D(0, -100, 0);
            Vector3D normal = new Vector3D(0, 1, 0);
            Plane planeTest = new Plane(testPoint, normal);
            planeTest.SetMaterial(new Chalk(new ColorRGB(1, 0, 0)));
            sceneTestInstance.AddObject(planeTest);

            Tracer testTracer = new Tracer(sceneTestInstance);
            sceneTestInstance.SetTracer(testTracer);

            Mirror mirror = new Mirror();
            hitInfo.hasHit = true;
            //Act
            ColorRGB color = mirror.CalculateShade(hitInfo, sceneTestInstance);
            //Assert
            Assert.IsFalse(color.Equals(sceneTestInstance.GetBackgroundColor()));
        }
    }
}
