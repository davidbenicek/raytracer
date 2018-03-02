using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Lights;
using RayTracer.Models.Materials;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Tracing;

namespace RayTracer.Tests.TracingTest
{
    [TestFixture]
    public class TracerTest
    {
        Tracer testTracer;
        SceneTestInstance sceneTestInstance;
        WindowFrame winFrame;

        [TestFixtureSetUp]
        public void Init()
        {
            winFrame = new WindowFrame(2000, 2000);
        }

        [Test]
        public void TestTraceRay_NullHitInfo()
        {
            //Arrange

            sceneTestInstance = new SceneTestInstance(winFrame);
            sceneTestInstance.SetValue(0);
            Point3D zeroOrigin = new Point3D(0);
            Vector3D zeroVector = new Vector3D(0);
            Ray testRay = new Ray(zeroOrigin, zeroVector);

            testTracer = new Tracer(sceneTestInstance);
            //Act
            ColorRGB colorResult = testTracer.TraceRay(testRay);

            Assert.IsTrue(sceneTestInstance.GetBackgroundColor().Equals(colorResult));

        }

        [Test]
        public void TestTraceRay_NotNullHitInfo_AndNotHit()
        {
            //Arrange
            sceneTestInstance = new SceneTestInstance(winFrame);
            sceneTestInstance.SetValue(1);
            Point3D zeroOrigin = new Point3D(0);
            Vector3D zeroVector = new Vector3D(0);
            Ray testRay = new Ray(zeroOrigin, zeroVector);

            testTracer = new Tracer(sceneTestInstance);
            //Act
            ColorRGB colorResult = testTracer.TraceRay(testRay);

            Assert.IsTrue(sceneTestInstance.GetBackgroundColor().Equals(colorResult));
        }

        [Test]
        public void TestTraceRay_NotNullHitInfo_AndNoObjectsInTheScene()
        {
            //Arrange
            sceneTestInstance = new SceneTestInstance(winFrame);
            sceneTestInstance.SetValue(2);
            Point3D zeroOrigin = new Point3D(0);
            Vector3D zeroVector = new Vector3D(0);
            Ray testRay = new Ray(zeroOrigin, zeroVector);

            testTracer = new Tracer(sceneTestInstance);
            //Act
            ColorRGB colorResult = testTracer.TraceRay(testRay);

            Assert.IsTrue(sceneTestInstance.GetBackgroundColor().Equals(colorResult));
        }

        [Test]
        public void TestTraceRay_NotNullHitInfo_WithObjectsInTheSceneWithoutHit()
        {
            //Arrange
            sceneTestInstance = new SceneTestInstance(winFrame);
            sceneTestInstance.SetValue(2);

            Point3D testPoint = new Point3D(0, -100, 0);
            Vector3D normal = new Vector3D(0, 1, 0);
            Plane planeTest = new Plane(testPoint, normal);
            sceneTestInstance.AddObject(planeTest);
            Point3D zeroOrigin = new Point3D(0);
            Vector3D zeroVector = new Vector3D(0);
            Ray testRay = new Ray(zeroOrigin, zeroVector);

            testTracer = new Tracer(sceneTestInstance);
            //Act
            ColorRGB colorResult = testTracer.TraceRay(testRay);
            //Assert
            Assert.IsTrue(sceneTestInstance.GetBackgroundColor().Equals(colorResult));
        }

        //This test case assumes that the color of the object is different than the background.
        [Test]
        public void TestTraceRay_NotNullHitInfo_WithObjectsInTheSceneWithHitWithoutLights()
        {
            //Arrange
            sceneTestInstance = new SceneTestInstance(winFrame);
            sceneTestInstance.SetValue(2);
            Point3D testPoint = new Point3D(0, -100, 0);
            Vector3D normal = new Vector3D(0, 1, 0);
            Plane planeTest = new Plane(testPoint, normal);
            planeTest.SetMaterial(new Chalk(new ColorRGB(1, 0, 0)));
            sceneTestInstance.AddObject(planeTest);
            Vector3D rayDirection = new Vector3D(-0.6, -0.8, -0.99);
            Point3D rayOrigin = new Point3D(0, 30, 300);
            Ray testRay = new Ray(rayOrigin, rayDirection);

            testTracer = new Tracer(sceneTestInstance);
            //Act
            ColorRGB colorResult = testTracer.TraceRay(testRay);
            //Assert
            Assert.IsFalse(sceneTestInstance.GetBackgroundColor().Equals(colorResult));
        }

        [Test]
        public void TestTraceRay_NotNullHitInfo_WithObjectsInTheSceneWithHitWithLights()
        {
            //Arrange
            sceneTestInstance = new SceneTestInstance(winFrame);
            sceneTestInstance.SetValue(2);

            Point3D lightPos = new Point3D(100);
            ColorRGB lightColor = new ColorRGB(1, 0, 0);
            sceneTestInstance.AddLight(new Light(lightPos, lightColor));

            Point3D testPoint = new Point3D(0, -100, 0);
            Vector3D normal = new Vector3D(0, 1, 0);
            Plane planeTest = new Plane(testPoint, normal);
            planeTest.SetMaterial(new Chalk(new ColorRGB(1,0,0)));
            sceneTestInstance.AddObject(planeTest);

            Vector3D rayDirection = new Vector3D(-0.6, -0.8, -0.99);
            Point3D rayOrigin = new Point3D(0, 30, 300);
            Ray testRay = new Ray(rayOrigin, rayDirection);

            testTracer = new Tracer(sceneTestInstance);
            //Act
            ColorRGB colorResult = testTracer.TraceRay(testRay);
            //Assert
            Assert.IsFalse(sceneTestInstance.GetBackgroundColor().Equals(colorResult));
        }
    }
}
