using System;

namespace ARandom
{
    public partial class RandomGenerator
    {
        private bool CreateBuffer;
        private double GaussBuffer;

        /// <summary>
        /// Generates random number following normal distribution. 
        /// </summary>
        /// <param name="mean">Mean of normal distribution.</param>
        /// <param name="standardDev">Standard deviation of normal distribution.</param>
        /// <returns>Random number following normal distribution.</returns>
        /// <seealso cref="RandomGenerator.Next()"/>
        public double NextGauss(double mean = 1, double standardDev = 1)
        {
            if (CreateBuffer ^= true)
            {
                double a1 = this.NextDouble();
                double a2 = this.NextDouble();

                double v1 = 2 * a1 - 1;
                double v2 = 2 * a2 - 1;

                double w = v1 * v1 + v2 * v2;

                double marsgaliaTransform =  Math.Sqrt(-2 * Math.Log(w) / w);

                GaussBuffer = v1 * marsgaliaTransform;

                return mean + standardDev * v2 * marsgaliaTransform;
            }

            return mean + standardDev * GaussBuffer;
        }

        /// <summary>
        /// Generates random number following normal distribution remapped and constrained to given range.
        /// </summary>
        /// <param name="min">Bottom bound of range.</param>
        /// <param name="max">Upper bound of range.</param>
        /// <param name="mean">Mean of normal distribution.</param>
        /// <param name="standardDev">Standard deviation of normal distribution.</param>
        /// <returns>Random number following normal distribution remapped and constrained to match given range.</returns>
        /// <seealso cref="NextGauss(double, double)"/>
        public double NextGaussRange(double min, double max, double mean = 1, double standardDev = 1)
        {
            var (Min, Max) = Utilities.GetGaussianApproxRange(mean, standardDev);
            double result = (this.NextGauss() - Min) / (Max - Min) * (max - min) + min;
            return Utilities.Clamp(result, min, max);
        }
    }
}
