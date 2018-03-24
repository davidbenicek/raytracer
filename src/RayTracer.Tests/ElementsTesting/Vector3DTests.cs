using System;
using NUnit.Framework;
using RayTracer.Models.Elements;

namespace RayTracer.Tests.ElementsTesting
{
    [TestFixture]
    public class Vector3DTests
    {
        [Test]
        public void TestAddVectors()
        {
            Vector3D vectorA = new Vector3D(1, 2, 1);
            Vector3D vectorB = new Vector3D(1, 2, 1);
            Vector3D actualVector = vectorA + vectorB;
            Vector3D expected = new Vector3D(2, 4, 2);

            Assert.IsTrue(actualVector.Equals(expected));
        }

        [Test]
        public void TestSubVector()
        {
            Vector3D vectorA = new Vector3D(1, 2, 1);
            Vector3D vectorB = new Vector3D(1, 2, 1);
            Vector3D actualVector = vectorA - vectorB;
            Vector3D expected = new Vector3D(0, 0, 0);

            Assert.IsTrue(actualVector.Equals(expected));
        }

        [Test]
        public void TestSubSingleVector()
        {
            Vector3D vectorA = new Vector3D(1, 1, 1);
            Vector3D actualVector = -vectorA;
            Vector3D expected = new Vector3D(-1, -1, -1);

            Assert.IsTrue(actualVector.Equals(expected));
        }

        [Test]
        public void TestProdVectorScale()
        {
            Vector3D vectorA = new Vector3D(1, 1, 1);
            double scaleV = 2.0;
            Vector3D actualVector = vectorA * scaleV;
            Vector3D expected = new Vector3D(2, 2, 2);

            Assert.IsTrue(actualVector.Equals(expected));
        }

        [Test]
        public void TestProdScaleVector()
        {
            double scaleV = 2.0;
            Vector3D vectorA = new Vector3D(1, 1, 1);
            Vector3D actualVector = scaleV * vectorA;
            Vector3D expected = new Vector3D(2, 2, 2);

            Assert.IsTrue(actualVector.Equals(expected));
        }

        [Test]
        public void TestDivVectorScale()
        {
            Vector3D vectorA = new Vector3D(4, 4, 4);
            double scaleV = 2.0;
            Vector3D actualVector = vectorA / scaleV;
            Vector3D expected = new Vector3D(2, 2, 2);

            Assert.IsTrue(actualVector.Equals(expected));
        }

        [Test]
        public void TestDotProduct()
        {
            Vector3D vectorA = new Vector3D(2, 2, 2);
            double expected = 12;

            Assert.IsTrue(vectorA.DotProduct(new Vector3D(2, 2, 2)).Equals(expected));
        }

        [Test]
        public void TestCrossProduct()
        {
            Vector3D vectorA = new Vector3D(2, 2, 2);
            Vector3D actualVector = vectorA.CrossProduct(new Vector3D(2, 2, 2));
            Vector3D expected = new Vector3D(0, 0, 0);

            Assert.IsTrue(actualVector.Equals(expected));
        }

        [Test]
        public void TestLengthBeforeSqrt()
        {
            Vector3D vectorA = new Vector3D(2, 2, 2);
            double expected = 12.0;

            Assert.IsTrue(vectorA.LengthBeforeSqrt().Equals(expected));
        }

        [Test]
        public void TestLength()
        {
            Vector3D vectorA = new Vector3D(2, 2, 2);
            double actualResult = Math.Round(vectorA.Length(),2);
            double expected = 3.46;

            Assert.IsTrue(actualResult.Equals(expected));
        }

        [Test]
        public void TestNormalize()
        {
            Vector3D vector = new Vector3D(10, 10, 10);
            vector.Normalize();

            Vector3D expected = new Vector3D(0.58, 0.71, 1);

            Assert.IsTrue(expected.x.Equals(Math.Round(vector.x, 2)) &&
                          expected.y.Equals(Math.Round(vector.y, 2)) &&
                          expected.z.Equals(Math.Round(vector.z, 2)));
        }

    }
}
