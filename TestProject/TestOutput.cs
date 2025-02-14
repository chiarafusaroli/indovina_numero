using LibraryProject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class TestOutput : IOutputInterface
    {
        public AttemptResult lastAttemptResult { get; private set; }
        public GameStatus lastGameStatus { get; private set; }
        //avrebbe senso utilizzare un output su un sitema di log ma per semplicità utilizziamo un output su console di Debug
        void IOutputInterface.OutputAttemptResult(AttemptResult result)
        {
            lastAttemptResult = result;
            Debug.WriteLine($"RISULTATO TENTATIVO: {result.ToString()}");            
        }

        void IOutputInterface.OutputGameStatus(GameStatus status)
        {
            lastGameStatus = status;
            Debug.WriteLine($"STATO PARTITA: {status.ToString()}");
        }
    }
}
