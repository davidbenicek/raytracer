using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Materials;

namespace RayTracer.Tests.Controllers
{
    [TestFixture]
    public class CubeTest
    {
        [Test]
        public void CubeTestMethod()
        {
            Cube cube = new Cube(new Point3D(0), new Point3D(70), new Plastic(new ColorRGB(1, 0, 0)));

            if (cube.maxPoint.x == (cube.minPoint.x) && cube.maxPoint.y == (cube.minPoint.y)
               && cube.maxPoint.z == (cube.minPoint.z))
            {
                Assert.IsTrue(false);
            }
            else
            {
                Assert.IsTrue(true);
            }

        }
    }
}
