﻿using System;
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
        public void TestTGreaterthanKEpsilon()
        {
            Sphere testSphere = new Sphere();
            HitInfo hitInfo = testSphere.Intersect((new Ray(new Point3D(0), new Vector3D(2))));
            Assert.IsTrue(hitInfo.hasHit);
<<<<<<< HEAD
=======
        }

        [Test]
        public void TestTGreaterThanKEpsilonAndOriginNotZero()
        {
            Sphere testSphere = new Sphere(new Point3D(50, 0, 0), 40, new Plastic(new ColorRGB(1, 0, 0)));
            HitInfo hitInfo = testSphere.Intersect((new Ray(new Point3D(0,30,300), new Vector3D(0.16,-0.23, -0.99))));
            Assert.IsTrue(hitInfo.hasHit);
>>>>>>> d5a75c80a7c0bdf62673e4af36c4217f0161c8b8
        }

        [Test]
        public void TestTLessthanKEpsilon()
        {
            
        }
    }
}