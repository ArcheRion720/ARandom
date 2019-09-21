using System;

namespace ARandom
{
    public partial class RandomGenerator
    {
        private const ushort ArraySize = 256;
        private const ushort ArrayMask = 255;
        private double[] noiseSeed;
        private ushort[] permutations;

        /// <summary>
        /// Returns noise value at specified coordinates. The result is always number between 0.0 and 1.0. 
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <returns>Noise value at coordinate coordinates.</returns>
        public double Noise(double x) => Noise(x, 0, 0);

        /// <summary>
        /// Returns noise value at specified coordinates. The result is always number between 0.0 and 1.0. 
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Noise value at coordinate coordinates.</returns>
        public double Noise(double x, double y) => Noise(x, y, 0);

        /// <summary>
        /// Returns noise value at specified coordinates. The result is always number between 0.0 and 1.0. 
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <returns>Noise value at coordinate coordinates.</returns>
        public double Noise(double x, double y, double z)
        {
            int xi = (int)Math.Floor(x);
            int yi = (int)Math.Floor(y);
            int zi = (int)Math.Floor(z);

            double tx = x - xi;
            double ty = y - yi;
            double tz = z - zi;

            int rx0 = xi & ArrayMask;
            int rx1 = (rx0 + 1) & ArrayMask;
            int ry0 = yi & ArrayMask;
            int ry1 = (ry0 + 1) & ArrayMask;
            int rz0 = zi & ArrayMask;
            int rz1 = (rz0 + 1) & ArrayMask;

            double c000 = noiseSeed[permutations[permutations[permutations[rx0] + ry0] + rz0]];
            double c001 = noiseSeed[permutations[permutations[permutations[rx0] + ry0] + rz1]];
            double c010 = noiseSeed[permutations[permutations[permutations[rx0] + ry1] + rz0]];
            double c011 = noiseSeed[permutations[permutations[permutations[rx0] + ry1] + rz1]];
            double c100 = noiseSeed[permutations[permutations[permutations[rx1] + ry0] + rz0]];
            double c110 = noiseSeed[permutations[permutations[permutations[rx1] + ry1] + rz0]];
            double c101 = noiseSeed[permutations[permutations[permutations[rx1] + ry0] + rz1]];
            double c111 = noiseSeed[permutations[permutations[permutations[rx1] + ry1] + rz1]];

            double sx = SmoothStep(tx);
            double sy = SmoothStep(ty);
            double sz = SmoothStep(tz);

            double nx0 = Lerp(c000, c100, sx);
            double nx1 = Lerp(c010, c110, sx);
            double nx2 = Lerp(c001, c101, sx);
            double nx3 = Lerp(c011, c111, sx);

            double ny0 = Lerp(nx0, nx1, sy);
            double ny1 = Lerp(nx2, nx3, sy);

            return Lerp(ny0, ny1, sz);
        }

        private static double SmoothStep(double value) => value * value * (3 - 2 * value);

        private static double Lerp(double start, double stop, double delta) => start * (1 - delta) + stop * delta;

        private void SetupNoise()
        {
            noiseSeed = new double[ArraySize];
            permutations = new ushort[ArraySize * 2];

            for (ushort i = 0; i < ArraySize; i++)
            {
                noiseSeed[i] = this.NextDouble();
                permutations[i] = i;
            }

            this.ShuffleArray(permutations, 0, ArraySize);
            Array.Copy(permutations, 0, permutations, ArraySize, ArraySize);
        }
    }
}
