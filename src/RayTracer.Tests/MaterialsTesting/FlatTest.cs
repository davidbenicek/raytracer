using System;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Materials;
using RayTracer.Models.Util;

namespace RayTracer.Tests.MaterialsTesting
{
    [TestFixture]
    public class FlatTest
    {
        [Test]
        public void TestCalculateShade_DefaultColor()
        {
            //Arrange
            Flat testFlat = new Flat();
            //Act
            ColorRGB actualColor = testFlat.CalculateShade(null);
            //Assert
            Assert.IsTrue(actualColor.Equals(Config.WHITE));
        }

        [Test]
        public void TestCalculateShade_CustomColor()
        {
            //Arrange
            Flat testFlat = new Flat(new ColorRGB(0.5));
            //Act
            ColorRGB expectedColor = new ColorRGB(0.5);
            ColorRGB actualColor = testFlat.CalculateShade(null);
            //Assert
            Assert.IsTrue(actualColor.Equals(expectedColor));
        }
    }
}
