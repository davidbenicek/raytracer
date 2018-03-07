using System;
using System.Collections.Generic;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Sampling
{
    public abstract class Sampler
    {
        protected int numOfsamples;
        protected int numOfsets;
        protected List<Point2D> samples;
        int count = 0;
        int jump = 0;

        public Sampler()
        {
            samples = new List<Point2D>();
            numOfsets = Config.NUM_OF_SETS;
            jump = 0;
            count = 0;
        }

        public Sampler(int numOfsamples)
        {
            numOfsets = Config.NUM_OF_SETS;
            this.numOfsamples = numOfsamples;
            jump = 0;
            count = 0;
            samples = new List<Point2D>();
        }

        public Sampler(int numOfsamples, int numOfSets)
        {
            this.numOfsamples = numOfsamples;
            this.numOfsets = numOfSets;
            jump = 0;
            count = 0;
            samples = new List<Point2D>();
        }

        public int GetNoSamples()
        {
            return numOfsamples;
        }

        public Point2D NextSample()
        {
            if (count % numOfsamples == 0)
            { // New Pixel
                jump = new Random().Next() % numOfsets;
            }
            return samples[(jump + count++) % (numOfsamples * numOfsets)];
        }

        public List<Point2D> GetSamples()
        {
            return samples;
        }

        public abstract void GenerateSamples();
    }
}
