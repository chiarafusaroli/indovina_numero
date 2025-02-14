using ConsoleProject;
using LibraryProject;
using System.Runtime.CompilerServices;

namespace DemoProgettoCompleto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tentativi = 10;
            int maxNumero = 100;
            Console.WriteLine("************** GIOCO INDOVINA IL NUMERO **************");
            Console.WriteLine($"Hai {tentativi} tentativi per indovinare un numero compreso tra 1 e {maxNumero}");
            GuessTheNamberGame game = new GuessTheNamberGame(tentativi,maxNumero, new UserInputConsole(), new UserOutputConsole());            
        }

       
    }
}
