using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public interface IOutputInterface
    {
        void OutputGameStatus(GameStatus status);
        void OutputAttemptResult(AttemptResult result);
        
    }
}
