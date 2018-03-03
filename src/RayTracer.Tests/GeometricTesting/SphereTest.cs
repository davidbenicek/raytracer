using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Tests.GeometricTesting
{
    [TestFixture]
    public class SphereTest
    {
        
        [Test]
        public void TestIntersection_DiscriminantLessThan0()
        {
            Sphere testSphere = new Sphere();
            HitInfo hitInfo = testSphere.Intersect(new Ray(new Point3D(0), new Vector3D(0)));
            Assert.IsFalse(hitInfo.hasHit);
        }

        [Test]
        public void TestIntersection_DiscriminantEqualorGreaterThan0()
        {
            Sphere testSphere = new Sphere();
            HitInfo hitInfo = testSphere.Intersect(new Ray(new Point3D(0), new Vector3D(2)));
            Assert.IsTrue(hitInfo.hasHit);
        }

        [Test]
        public void TestIntersection_DenominatorEquals0()
        {
            Sphere testSphere = new Sphere();
            HitInfo hitInfo = testSphere.Intersect((new Ray(new Point3D(0), new Vector3D(0))));
            Assert.IsFalse(hitInfo.hasHit);
        }

        [Test]
        public void TestIntersection_DenominatorGreaterThan0()
        {
            Sphere testSphere = new Sphere();
            HitInfo hitInfo = testSphere.Intersect((new Ray(new Point3D(0), new Vector3D(2))));
            Assert.IsTrue(hitInfo.hasHit);
        }

        [Test]
        public void TestTGreaterthanKEpsilonAndRayOriginEqualsZero()
        {
            Sphere testSphere = new Sphere();
            HitInfo hitInfo = testSphere.Intersect((new Ray(new Point3D(0), new Vector3D(2))));
            Assert.IsTrue(hitInfo.hasHit);
        }

        [Test]
        public void TestTGreaterThanKEpsilonAndRayOriginNotZero()
        {
            Sphere testSphere = new Sphere(new Point3D(50, 0, 0), 40, new Plastic(new ColorRGB(1, 0, 0)));
            HitInfo hitInfo = testSphere.Intersect((new Ray(new Point3D(0,30,300), new Vector3D(0.16,-0.23, -0.99))));
            Assert.IsTrue(hitInfo.hasHit);
        }

        [Test]
        public void TestTLessthanKEpsilon()
        {
            
        }
    }
}