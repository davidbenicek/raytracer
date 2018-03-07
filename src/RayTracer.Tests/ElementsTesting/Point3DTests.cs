using System;
using NUnit.Framework;
using RayTracer.Models.Elements;

namespace RayTracer.Tests.ElementsTesting
{
    [TestFixture]
    public class Point3DTests
    {
        [Test]
        public void TestAddPoints()
        {
            Point3D pointA = new Point3D(0, 2, 1);
            Point3D pointB = new Point3D(1, 2, -1);
            Point3D actualPointer = pointA + pointB;

            Point3D expected = new Point3D(1, 4, 0);

            Assert.IsTrue(actualPointer.Equals(expected));
        }

        [Test]
        public void TestAddPointVector()
        {
            Point3D pointA = new Point3D(2, 2, 2);
            Vector3D vectorA = new Vector3D(1, 1, 1);
            Point3D actualPointer = pointA + vectorA;

            Point3D expected = new Point3D(3, 3, 3);

            Assert.IsTrue(actualPointer.Equals(expected));
        }

        [Test]
        public void TestSubPointVector()
        {
            Point3D pointA = new Point3D(2, 2, 2);
            Vector3D vectorA = new Vector3D(1, 1, 1);
            Point3D actualPointer = pointA - vectorA;

            Point3D expected = new Point3D(1, 1, 1);

            Assert.IsTrue(actualPointer.Equals(expected));
        }

        [Test]
        public void TestSubPoints()
        {
            Point3D pointA = new Point3D(2, 2, 2);
            Point3D pointB = new Point3D(1, 1, 1);
            Vector3D actualPointer = pointA - pointB;

            Vector3D expected = new Vector3D(1, 1, 1);

            Assert.IsTrue(actualPointer.Equals(expected));
        }

        [Test]
        public void TestProductPointScale()
        {
            Point3D pointA = new Point3D(2, 2, 2);
            Double scaleA = 2.0;
            Point3D actualPointer = pointA * scaleA;

            Point3D expected = new Point3D(4.0, 4.0, 4.0);

            Assert.IsTrue(actualPointer.Equals(expected));
        }

        [Test]
        public void TestProductScalePoint()
        {
            Double scaleA = 2.0;
            Point3D pointA = new Point3D(2, 2, 2);
            Point3D actualPointer = scaleA * pointA;

            Point3D expected = new Point3D(4.0, 4.0, 4.0);

            Assert.IsTrue(actualPointer.Equals(expected));
        }

        [Test]
        public void TestGetDistanceBeforeSqrt()
        {
            Point3D pointA = new Point3D(2, 2, 2);
            Point3D pointB = new Point3D(1, 1, 1);
            double actualResult = pointA.GetDistanceBeforeSqrt(pointB);

            double expected = 3.0;

            Assert.IsTrue(actualResult.Equals(expected));
        }

        [Test]
        public void TestGetDistance()
        {
            Point3D pointA = new Point3D(2, 2, 2);
            Point3D pointB = new Point3D(1, 1, 1);
            double actualResult = Math.Sqrt(pointA.GetDistanceBeforeSqrt(pointB));
            actualResult = Math.Round(actualResult, 2);
            double expected = 1.73;
            Assert.IsTrue(actualResult.Equals(expected));
        }

    }
}

