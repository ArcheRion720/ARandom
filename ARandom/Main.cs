using System;

namespace ARandom
{
    /// <summary>
    /// Represents pseudo-random number generator producing numbers based on given seed.
    /// </summary>
    public partial class RandomGenerator
    {
        private long seed;
        private const long multiplier = 0x8088405;
        private const long increment = 0xC39EC3;
        private const long modulus = 2147483647L;

        private static long DefaultSeed => Environment.TickCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class
        /// </summary>
        public RandomGenerator() : this(DefaultSeed) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class
        /// </summary>
        /// <param name="seed">Seed that will be used in process of generating random numbers.</param>
        public RandomGenerator(long seed)
        {
            this.seed = seed % modulus;

            SetupNoise();
        }

        private long Forward()
        {
            seed = (multiplier * seed + increment) % modulus;
            return seed;
        }
    }
}
