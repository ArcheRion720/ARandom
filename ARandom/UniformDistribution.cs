using System;

namespace ARandom
{
    public partial class RandomGenerator
    {
        /// <summary>
        /// Generates random non-negative number.
        /// </summary>
        /// <returns>Random non-negative integer.</returns>
        /// <seealso cref="Next(int, int)"/>
        public int Next()
        {
            return (int)Generator.Forward();
        }

        /// <summary>
        /// Generates random number within range of 0 to given max.
        /// </summary>
        /// <param name="max">Exclusive upper bound of range.</param>
        /// <returns>Random integer withing given range.</returns>
        /// <seealso cref="Next(int, int)"/>
        public int Next(int max)
        {
            return Next(0, max);
        }

        /// <summary>
        /// Generates random number within given range.
        /// </summary>
        /// <param name="min">Inclusive bottom bound of range.</param>
        /// <param name="max">Exclusive upper bound of range.</param>
        /// <returns>Random integer withing given range.</returns>
        /// <seealso cref="Next"/>
        public int Next(int min, int max)
        {
            return min + (this.Next() % (max - min));
        }

        /// <summary>
        /// Generates random floating-point number between 0.0 and 1.0.
        /// </summary>
        /// <returns>Random floating-point number between 0.0 and 1.0.</returns>
        public double NextDouble()
        {
            return Generator.NextDouble();
        }

        /// <summary>
        /// Generates random floating-point number within given range.
        /// </summary>
        /// <param name="min">Inclusive bottom bound of range.</param>
        /// <param name="max">Exclusive upper bound of range.</param>
        /// <returns>Random floating-point number within given range.</returns>
        public double NextDouble(double min, double max)
        {
            return min + (max - min) * this.NextDouble();
        }
    }
}
