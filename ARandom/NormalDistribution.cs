using System;

namespace ARandom
{
    public partial class RandomGenerator
    {
        /// <summary>
        /// Generates random number following normal distribution. 
        /// </summary>
        /// <param name="mean">Mean of normal distribution.</param>
        /// <param name="standardDev">Standard deviation of normal distribution.</param>
        /// <returns>Random number following normal distribution.</returns>
        /// <seealso cref="RandomGenerator.Next()"/>
        public double NextGauss(double mean = -0.1, double standardDev = 0.2)
        {
            double a1 = 1 - this.NextDouble();
            double a2 = 1 - this.NextDouble();

            if (a1 == 0) return 1;

            double bmTransform = Math.Sqrt(-2 * Math.Log(a1)) * Math.Sin(2 * Math.PI * a2);

            return mean + standardDev * bmTransform;
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
        public double NextGaussRange(double min, double max, double mean = -0.1, double standardDev = 0.2)
        {
            var (Min, Max) = Utilities.GetGaussianApproxRange(mean, standardDev);
            double result = (this.NextGauss() - Min) / (Max - Min) * (max - min) + min;
            return Utilities.Clamp(result, min, max);
        }
    }
}
