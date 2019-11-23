using System;
using System.Collections.Generic;
using System.Text;

namespace ARandom
{
    public class LCG : INumberGenerator
    {
        private ulong seed;
        private const long multiplier = 0x1FFFFFFF; //536870911
        private const long increment = 0x24CFC7; //2412487
        private const long modulus = 0xFFFFFFF; //268435455

        public LCG(long seed)
        {
            this.seed = (ulong)seed;
            Forward();
        }

        public double NextDouble()
        {
            return Forward() / (modulus - 1d);
        }

        public long Forward()
        {
            seed = (seed * multiplier + increment) % modulus;
            return (long)(seed & 0x7FFFFFFFFFFFFFFF);
        }
    }
}
