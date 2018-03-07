using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Tests.CamerasTesting
{
    [TestFixture]
    public class PerspectiveTest
    {
        Point2D point = new Point2D();
        public double distanceViewPlane = 850;
        Point3D u = new Point3D(0.99896255, 0, -0.016587);
        Point3D v = new Point3D(-0.00164, 1.000137, -0.009949);
        Point3D w = new Point3D(0.016581, 0.0995037188, 0.9999999434);

        [Test]
        public void TestFindRayDirection()
        {
            Vector3D rayDirection = point.x * u + point.y * v - distanceViewPlane * w;
            Vector3D newRayDirection= point.x * u + point.y * v - distanceViewPlane * w;
            rayDirection.Normalize();
            Assert.IsFalse(rayDirection.Equals(newRayDirection));
        }
            
    }
}
