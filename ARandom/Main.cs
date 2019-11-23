using System;

namespace ARandom
{
    /// <summary>
    /// Represents pseudo-random number generator producing numbers based on given seed.
    /// </summary>
    public partial class RandomGenerator
    {

        private static long DefaultSeed => Environment.TickCount;
        private static INumberGenerator Generator { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class
        /// </summary>
        public RandomGenerator() : this(DefaultSeed, GeneratorType.LCG) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class
        /// </summary>
        /// <param name="seed">Seed that will be used in process of generating random numbers.</param>
        public RandomGenerator(long seed) : this(seed, GeneratorType.LCG) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class
        /// </summary>
        /// <param name="type">Type of random number generation algorithm that will be used.</param>
        public RandomGenerator(GeneratorType type) : this(DefaultSeed, type) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class
        /// </summary>
        /// <param name="seed">Seed that will be used in process of generating random numbers.</param>
        /// <param name="type">Type of random number generation algorithm that will be used.</param>
        public RandomGenerator(long seed, GeneratorType type)
        {
            switch(type)
            {
                case GeneratorType.LCG:
                    Generator = new LCG(seed);
                    break;
                case GeneratorType.LFSR:
                    Generator = new LFSR(seed);
                    break;
                default:
                    throw new ArgumentException();
            }

            SetupNoise();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class
        /// </summary>
        /// <param name="generator">Random number generator algorithm instance that will be used.</param>
        public RandomGenerator(INumberGenerator generator)
        {
            Generator = generator;
            SetupNoise();
        }
    }

    public enum GeneratorType
    {
        LCG,
        LFSR 
    }
}
