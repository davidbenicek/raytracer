using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Lights;
using RayTracer.Models.Util;

namespace RayTracer.Tests.LightsTesting
{
    [TestFixture]
    public class LightTest
    {
        Light testLight;
        Point3D lightPosition;
        ColorRGB lightColor;
        double intensity;

        [TestFixtureSetUp]
        public void Init()
        {
            lightPosition = new Point3D(2);
            lightColor = new ColorRGB(0.6);
            intensity = 0.5;
            testLight = new Light(lightPosition, lightColor, intensity);   
        }

        [Test]
        public void TestGetDirection()
        {
            //Arrange
            Point3D surfacePoint = new Point3D(1);
            //Act
            Vector3D actualResult = testLight.GetDirection(surfacePoint);
            Vector3D expectedResult = new Vector3D(1,1,1);
            expectedResult.Normalize();
            //Assert
            Assert.IsTrue(actualResult.Equals(expectedResult));
        }

        [Test]
        public void TestGetDirectionOriginSurfacePoint()
        {
            //Arrange
            Point3D surfacePoint = new Point3D(0);
            //Act
            Vector3D actualResult = testLight.GetDirection(surfacePoint);
            Vector3D expectedResult = new Vector3D(2);
            expectedResult.Normalize();
            //Assert
            Assert.IsTrue(actualResult.Equals(expectedResult));
        }

        [Test]
        public void TestGetDistance()
        {
            //Arrange
            Point3D surfacePoint = new Point3D(0);
            //Act
            double actualValue = testLight.GetDistance(surfacePoint);
            double expectedValue = lightPosition.GetDistance(surfacePoint);
            //Assert
            Assert.IsTrue(actualValue.Equals(expectedValue));
        }

        [Test]
        public void TestGetColor()
        {
            //Arrange
            HitInfo hitInfo = new HitInfo();
            Point3D hitPoint = new Point3D(0);
            hitInfo.hitPoint = hitPoint;

            ColorRGB expectedColor = (100.0 / lightPosition.GetDistance(hitPoint))* lightColor * intensity ;
            //Act
            ColorRGB actualColor = testLight.GetColor(hitInfo);
            //Assert
            Assert.IsTrue(actualColor.Equals(expectedColor));
        }
    }
}
