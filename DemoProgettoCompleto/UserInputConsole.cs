using LibraryProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class UserInputConsole : IInputInterface
    {
       
        public async Task<int> InputAttempt()
        {
            int number;
            do
            {
                Console.WriteLine("Fai il tuo tentativo. Inserisci un numero:");
            } while (int.TryParse(Console.ReadLine(), out number) == false);

            return number;
            /*
            int number;
            do
            {
                Console.WriteLine("Fai il tuo tentativo. Inserisci un numero:");
                string input = await Task.Run(() => Console.ReadLine());
            } while (int.TryParse(Console.ReadLine(), out number) == false);

            return number;
            */
        }
    }
}
