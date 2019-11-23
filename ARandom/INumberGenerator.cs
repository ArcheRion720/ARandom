using System;
using System.Collections.Generic;
using System.Text;

namespace ARandom
{
    public interface INumberGenerator
    {
        long Forward();
        double NextDouble();
    }
}
