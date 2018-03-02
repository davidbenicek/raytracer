using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Util;

namespace RayTracer.Tests.Controllers
{
    [TestFixture]
    public class PlaneTest
    {
        Plane planeTest;
        Point3D testPoint;
        Vector3D normal;

        [TestFixtureSetUp]
        public void Init()
        {
            testPoint = new Point3D(0, -100, 0);
            normal = new Vector3D(0, 1, 0);
            planeTest = new Plane(testPoint, normal);
        }

        [Test]
        public void TestIntersect_DenomIsZero()
        {
            //Arrange
            Point3D zeroOrigin = new Point3D(0);
            Vector3D zeroVector = new Vector3D(0);
            Ray testRay = new Ray(zeroOrigin, zeroVector);
            //Act
            HitInfo hitInfoTest = planeTest.Intersect(testRay);
            //Assert
            Assert.IsFalse(hitInfoTest.hasHit);
        }

        [Test]
        public void TestIntersect_WithInValidTMinValue()
        {
            //Arrange
            Point3D rayOrigin = new Point3D(0, 30, 300);
            Vector3D rayDirection = new Vector3D(-0.7, 0.00038, -0.99);
            Ray testRay = new Ray(rayOrigin, rayDirection);
            //Act
            HitInfo hitInfoTest = planeTest.Intersect(testRay);
            Assert.IsTrue(hitInfoTest.tMin < Config.KEPSILON_VALUE);
        }

        [Test]
        public void TestIntersect_WithRayNotHit_TLessThanEpsilon()
        {
            //Arrange
            Point3D rayOrigin = new Point3D(0, 30, 300);
            Vector3D rayDirection = new Vector3D(-0.7, 0.00038, -0.99);
            Ray testRay = new Ray(rayOrigin, rayDirection);
            //Act
            HitInfo hitInfoTest = planeTest.Intersect(testRay);
            Assert.IsFalse(hitInfoTest.hasHit);
        }

        [Test]
        public void TestIntersect_WithValidTMinValue()
        {
            //Arrange
            Point3D rayOrigin = new Point3D(0, 30, 300);
            Vector3D rayDirection = new Vector3D(-0.6, -0.8, -0.99);
            Ray testRay = new Ray(rayOrigin, rayDirection);
            //Act
            HitInfo hitInfoTest = planeTest.Intersect(testRay);
            Assert.IsTrue(hitInfoTest.tMin > Config.KEPSILON_VALUE);
        }

        [Test]
        public void TestIntersect_WithValidCalculationsOfHitPoint()
        {
            //Arrange
            Point3D rayOrigin = new Point3D(0, 30, 300);
            Vector3D rayDirection = new Vector3D(-0.6, -0.8, -0.99);
            Ray testRay = new Ray(rayOrigin, rayDirection);
            //Act
            HitInfo hitInfoTest = planeTest.Intersect(testRay);
            Point3D expectedPoint = rayOrigin + (rayDirection * hitInfoTest.tMin);
            //Assert
            Assert.IsTrue(expectedPoint.Equals(hitInfoTest.hitPoint));
        }
    }
}
