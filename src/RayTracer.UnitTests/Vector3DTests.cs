using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracer.Models.Cameras;
using RayTracer.Models.Elements;

namespace RayTracer.UnitTests
{
    [TestClass()]
    public class Vector3DTests
    {
        [TestMethod()]
        public void TestAddVectors()
        {
            Vector3D vectorA = new Vector3D(1, 2, 1);
            Vector3D vectorB = new Vector3D(1, 2, 1);
            Vector3D actualVector = vectorA + vectorB;
            Vector3D expected = new Vector3D(2, 4, 2);

            Assert.IsTrue(actualVector.x == expected.x && actualVector.y == expected.y && actualVector.z == expected.z);
        }

        [TestMethod()]
        public void TestSubVector()
        {
            Vector3D vectorA = new Vector3D(1, 2, 1);
            Vector3D vectorB = new Vector3D(1, 2, 1);
            Vector3D actualVector = vectorA - vectorB;
            Vector3D expected = new Vector3D(0, 0, 0);

            Assert.IsTrue(actualVector.x == expected.x && actualVector.y == expected.y && actualVector.z == expected.z);
        }
    }
}
