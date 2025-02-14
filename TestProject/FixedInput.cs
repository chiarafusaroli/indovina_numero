using LibraryProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class FixedInput : IInputInterface
    {
        int _fixedNumber;

        public FixedInput(int value)
        {
            _fixedNumber = value;
        }

        public int InputAttempt()
        {
            return _fixedNumber;
        }
    }
}
