using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Lights;

namespace RayTracer.Tests.LightsTesting
{
    [TestFixture]
    public class AmbientLightTest
    {
        AmbientLight testAmbientLight;
        double intensity;
        ColorRGB lightColor;

        [TestFixtureSetUp]
        public void Init()
        {
            lightColor = new ColorRGB(0.2);
            intensity = 0.7;
            testAmbientLight = new AmbientLight(lightColor, intensity);
        }

        [Test]
        public void TestGetColor()
        {
            //Arrange
            ColorRGB expectedColor = intensity * lightColor;
            //Act
            ColorRGB actualColor = testAmbientLight.GetColor();
            //Assert
            Assert.IsTrue(expectedColor.Equals(actualColor));
        }

        [Test]
        public void TestGetDirection()
        {
            //Arrange
            Vector3D expectedDirection = new Vector3D(0);
            //Act
            Vector3D actualDirection = testAmbientLight.GetDirection(null);
            //Assert
            Assert.IsTrue(actualDirection.Equals(expectedDirection));
        }

        [Test]
        public void TestGetDistance()
        {
            //Arrange
            double expectedValue = 0;
            //Act
            double actualValue = testAmbientLight.GetDistance(null);
            //Assert
            Assert.IsTrue(expectedValue.Equals(actualValue));
        }
    }
}
