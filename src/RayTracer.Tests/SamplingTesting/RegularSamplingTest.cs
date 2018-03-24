using System;
using System.Collections.Generic;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Sampling;

namespace RayTracer.Tests.SamplingTesting
{
    [TestFixture]
    public class RegularSamplingTest
    {
        Sampler testSampler;
        List<Point2D> samples;
        double n;

        [TestFixtureSetUp]
        public void Init()
        {
            testSampler = new Regular(5);
            samples = testSampler.GetSamples();
            n = Math.Sqrt(5);


        }

        [Test]
        public void TestSampleValueAt0_0()
        {
            int position = 0 * (int) n + 0;
            Point2D expected = new Point2D(0, 0);

            Assert.IsTrue(expected.Equals(samples[position]));
        }

        [Test]
        public void TestSampleValueAt1_1()
        {
            int position = 1 * (int)n + 1 + 1;
            Point2D expected = new Point2D(1 / n, 1 / n);

            Assert.IsTrue(expected.Equals(samples[position]));
        }

        [Test]
        public void TestSampleValueAt2_2()
        {
            int position = (2 + 1)* (int)n + 2;
            Point2D expected = new Point2D(2 / n, 2 / n);

            Assert.IsTrue(expected.Equals(samples[position]));
        }

    }
}
