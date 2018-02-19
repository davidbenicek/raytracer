using System;
using RayTracer.Models.Elements;

namespace RayTracer.Models.Sampling
{
    public sealed class Regular : Sampler
    {
        public Regular()
            : base()
        {
            GenerateSamples();
        }

        public Regular(int numOfSamples, int numOfSets = 1)
            : base(numOfSamples, numOfSets)
        {
            GenerateSamples();
        }

        public override void GenerateSamples()
        {
            double n = Math.Sqrt(numOfsamples);
            for (int setIndex = 0; setIndex < numOfsets; ++setIndex)
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        Point2D NewSample = new Point2D(i / n, j / n);
                        samples.Add(NewSample);
                    }
                }
            }
        }
    }
}
