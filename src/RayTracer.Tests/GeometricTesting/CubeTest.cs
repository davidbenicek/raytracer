using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Tests.GeometricTesting
{
    [TestFixture]
    public class CubeTest
    {
        [Test]
        public void CubeTestMethod()
        {
            Cube cube = new Cube(new Point3D(0), new Point3D(70), new Plastic(new ColorRGB(1, 0, 0)));
            Assert.IsFalse(cube.maxPoint.Equals(cube.minPoint));
        }

        [Test]
        public void TestRayDirectionEqualszero()
        {
            Cube cube = new Cube(new Point3D(0), new Point3D(70), new Plastic(new ColorRGB(1, 0, 0)));
            HitInfo hitInfo = cube.Intersect(new Ray(new Point3D(0), new Vector3D(0)));
            Assert.IsTrue(hitInfo.hasHit);

        }

        [Test]
        public void TestRayDirectionLessThanzero()
        {
            Cube cube = new Cube(new Point3D(20), new Point3D(70), new Plastic(new ColorRGB(1, 0, 0)));
            HitInfo hitInfo = cube.Intersect(new Ray(new Point3D(0), new Vector3D(-2)));
            Assert.IsFalse(hitInfo.hasHit);
        }

        [Test]
        public void TestrayDirectionEqualsZeroAndCubeisHigher()
        {
            Cube cube = new Cube(new Point3D(50), new Point3D(70), new Plastic(new ColorRGB(1, 0, 0)));
            HitInfo hitInfo = cube.Intersect(new Ray(new Point3D(0), new Vector3D(0)));
            Assert.IsTrue(hitInfo.hasHit);
        }
    }
}