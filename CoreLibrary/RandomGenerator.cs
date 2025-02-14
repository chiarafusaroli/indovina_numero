using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public class RandomGenerator : INumberGenerator
    {
        int INumberGenerator.GenerateNumber(int maxNumber)
        {
            Random random = new Random();
            return random.Next(maxNumber);
        }
    }
}
