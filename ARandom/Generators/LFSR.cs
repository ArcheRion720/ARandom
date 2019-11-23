using System;
using System.Collections.Generic;
using System.Text;

namespace ARandom
{
    public class LFSR : INumberGenerator
    {
        private long Registry { get; set; }

        public LFSR(long seed)
        {
            Registry = seed;
            Shift();
        }

        private void Shift()
        {
            long feedback = ((Registry >> 31) & 1) ^ ((Registry >> 21) & 1) ^ ((Registry >> 1) & 1) ^ (Registry & 1);
            Registry = Registry >> 1 | feedback << 31;
        }

        public long Forward()
        {
            Shift();
            return Registry & 0x7FFFFFFF;
        }

        public double NextDouble()
        {
            return Forward() / (long.MaxValue - 1d);
        }
    }
}
