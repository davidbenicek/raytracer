using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
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
        public void TestTGreaterthanKEpsilon()
        {
            Sphere testSphere = new Sphere();
            HitInfo hitInfo = testSphere.Intersect((new Ray(new Point3D(0), new Vector3D(2))));
            Assert.IsTrue(hitInfo.hasHit);
            //I think theres an error. Shows True only when ray origin is 0
        }

        [Test]
        public void TestTLessthanKEpsilon()
        {
            
        }
    }
}