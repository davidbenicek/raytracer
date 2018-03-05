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

        [TestMethod()]
        public void TestSubSingleVector()
        {
            Vector3D vectorA = new Vector3D(1, 1, 1);
            Vector3D actualVector = -vectorA;
            Vector3D expected = new Vector3D(-1, -1, -1);

            Assert.IsTrue(actualVector.x == expected.x && actualVector.y == expected.y && actualVector.z == expected.z);
        }

        [TestMethod()]
        public void TestProdVectorScale()
        {
            Vector3D vectorA = new Vector3D(1, 1, 1);
            double scaleV = 2.0;
            Vector3D actualVector = vectorA * scaleV;
            Vector3D expected = new Vector3D(2, 2, 2);

            Assert.IsTrue(actualVector.x == expected.x && actualVector.y == expected.y && actualVector.z == expected.z);
        }

        [TestMethod()]
        public void TestProdScaleVector()
        {
            double scaleV = 2.0;
            Vector3D vectorA = new Vector3D(1, 1, 1);
            Vector3D actualVector = scaleV * vectorA;
            Vector3D expected = new Vector3D(2, 2, 2);

            Assert.IsTrue(actualVector.x == expected.x && actualVector.y == expected.y && actualVector.z == expected.z);           
        }

        [TestMethod()]
        public void TestDivVectorScale()
        {
            Vector3D vectorA = new Vector3D(4, 4, 4);
            double scaleV = 2.0;
            Vector3D actualVector = vectorA / scaleV;
            Vector3D expected = new Vector3D(2, 2, 2);

            Assert.IsTrue(actualVector.x == expected.x && actualVector.y == expected.y && actualVector.z == expected.z);
        }

        [TestMethod()]
        public void TestDotProduct()
        {
            Vector3D vectorA = new Vector3D(1, 1, 1);

        }
    }
}
