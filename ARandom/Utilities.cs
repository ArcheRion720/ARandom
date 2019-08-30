using System;

namespace ARandom
{
    /// <summary>
    /// Static class providing a set of utility methods.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Constrains a number to be within a range.
        /// </summary>
        /// <param name="value">Number to constrain.</param>
        /// <param name="min">Bottom bound of range.</param>
        /// <param name="max">Upper bound of range.</param>
        /// <returns>Value constrained in given range.</returns>
        public static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;

            return value;
        }

        /// <summary>
        /// Evaluates approximate range of normal distribution using empirical rule.
        /// </summary>
        /// <param name="mean">Mean of normal distribution.</param>
        /// <param name="stdDev">Standard deviation of normal distribution.</param>
        /// <returns>Tuple that contains approximate lower and upper bounds of normal distribution range.</returns>
        public static (double Min, double Max) GetGaussianApproxRange(double mean, double stdDev)
        {
            double delta = stdDev * 3;
            double a1 = mean - delta;
            double a2 = mean + delta;
            return (Math.Min(a1, a2), Math.Max(a1, a2));
        }
    }
}
