using LibraryProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class UserOutputConsole : IOutputInterface
    {
        public void OutputAttemptResult(AttemptResult result)
        {
            switch (result)
            {
                case AttemptResult.GUESSED:
                    Console.WriteLine("Bravo! Hai indovinato!");                    
                    break;
                case AttemptResult.TOO_BIG:
                    Console.WriteLine("Il numero è Troppo grande! Riprova.");
                    break;
                case AttemptResult.TOO_LITTLE:
                    Console.WriteLine("in numero è Troppo piccolo! Riprova.");
                    break;
            }
            
        }

        public void OutputGameStatus(GameStatus status)
        {
            if (status == GameStatus.WIN)
            {
                Console.WriteLine($"HAI VINTO!!!");
            }
            else if (status == GameStatus.LOSE)
            {
                Console.WriteLine($"HAI PERSO");
            }
            
        }
    }
}
