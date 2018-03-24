using System;
using NUnit.Framework;
using RayTracer.Models.Cameras;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Tests.CamerasTesting
{
    [TestFixture]
    public class PerspectiveTest
    {

        Point3D position;
        Point3D lookAt;
        double distanceViewPlane;
        Camera perspectiveCamera;

        [TestFixtureSetUp]
        public void Init()
        {
            position = new Point3D(0, 30, 300);
            lookAt = new Point3D(-5, 0, 0);
            distanceViewPlane = 850.0;
            perspectiveCamera = new Perspective(position, lookAt, distanceViewPlane);
        }

        [Test]
        public void TestFindRayDirection()
        {
            Point2D point = new Point2D(-999.56, -1000);
            Vector3D expectedRayDirection =new Vector3D(-0.61,-0.83,-1);
            Vector3D actualResult = perspectiveCamera.FindRayDirection(point);
            actualResult.x = Math.Round(actualResult.x, 2);
            actualResult.y = Math.Round(actualResult.y, 2);
            actualResult.z = Math.Round(actualResult.z, 2);

            Assert.IsTrue(actualResult.Equals(expectedRayDirection));
        }

        [Test]
        public void TestFindRayDirection_WithZeroValues_AndNotThrowingExceptions()
        {
            position = new Point3D(0);
            lookAt = new Point3D(0);
            distanceViewPlane = 850.0;

            perspectiveCamera = new Perspective(position, lookAt, distanceViewPlane);

            Point2D point = new Point2D(-999.56, -1000);
            Vector3D expectedRayDirection = new Vector3D(0);
            Vector3D actualResult = perspectiveCamera.FindRayDirection(point);

            Assert.IsTrue(actualResult.Equals(expectedRayDirection));
        }
            
    }
}
