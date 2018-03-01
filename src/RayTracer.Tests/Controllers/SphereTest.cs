using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Util;

namespace RayTracer.Tests.Controllers
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
    }
}
