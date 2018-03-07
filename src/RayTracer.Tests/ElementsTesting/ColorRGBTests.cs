using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RayTracer.Models.Elements;

namespace RayTracer.Tests.ElementsTesting
{
    [TestFixture]
    public class ColorRGBTests
    {
        [Test]
        public void TestAddColors()
        {
            ColorRGB colorA = new ColorRGB(1, 1, 1);
            ColorRGB colorB = new ColorRGB(1, 1, 1);
            ColorRGB actualColor = colorA + colorB;
            ColorRGB expected = new ColorRGB(2, 2, 2);

            Assert.IsTrue(actualColor.Equals(expected));

        }

        [Test]
        public void TestProdColors()
        {
            ColorRGB colorA = new ColorRGB(1, 1, 1);
            ColorRGB colorB = new ColorRGB(1, 1, 1);
            ColorRGB actualColor = colorA * colorB;
            ColorRGB expected = new ColorRGB(1, 1, 1);

            Assert.IsTrue(actualColor.Equals(expected));
        }

        [Test]
        public void TestProdScaleColor()
        {
            ColorRGB colorA = new ColorRGB(1, 1, 1);
            double scale = 2.0;
            ColorRGB actualColor = scale * colorA;
            ColorRGB expected = new ColorRGB(2, 2, 2);

            Assert.IsTrue(actualColor.Equals(expected));

        }

        [Test]
        public void TestProdColorScale()
        {
            ColorRGB colorA = new ColorRGB(1, 1, 1);
            double scale = 2.0;
            ColorRGB actualColor = colorA * scale;
            ColorRGB expected = new ColorRGB(2, 2, 2);

            Assert.IsTrue(actualColor.Equals(expected));
        }

        [Test]
        public void TestDivColorScale()
        {
            ColorRGB colorA = new ColorRGB(4, 4, 4);
            double scale = 2.0;
            ColorRGB actualColor = colorA / scale;
            ColorRGB expected = new ColorRGB(2, 2, 2);

            Assert.IsTrue(actualColor.Equals(expected));
        }

        [Test]
        public void TestPowColor()
        {
            ColorRGB colorA = new ColorRGB(2, 2, 2);
            double fac = 2.0;
            ColorRGB actualColor = colorA.Power(fac);
            ColorRGB expected = new ColorRGB(4, 4, 4);

            Assert.IsTrue(actualColor.Equals(expected));
        }
    }
}
