using LibraryProject;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace TestProject
{
    [TestClass]
    public class GameTest
    {
        /*
         * Questo progetto è molto semplice ed ora conel interfacce è anche testabile
         * Definiamo per i Test una classe FixedGenerator che implemnta l'interface IGenerator
         * e che restituisce come numeor da indovinare un numero fisso; in questo modo possiamo testare 
         * il corretto comportamento della partita 
         */

        [TestMethod]
        public void Attempts_attemptEqualsToNumberToGuess_GameStatusWin()
        {
            int fixedNumber = 100;
            FixedGenerator generator = new FixedGenerator(fixedNumber);
            FixedInput input = new FixedInput(fixedNumber);
            TestOutput output = new TestOutput();

            GuessTheNamberGame game = new GuessTheNamberGame(10, 100, input, output, generator);

            Assert.AreEqual(GameStatus.WIN, output.lastGameStatus);
        }
        
       
        [TestMethod]
        public void Attempts_attemptNotEqualsToNumerToGuessAndNoMoreRemainingAttempts_GameStatusLose()
        {
            int fixedNumber = 100;
            FixedGenerator generator = new FixedGenerator(fixedNumber);
            FixedInput input = new FixedInput(fixedNumber+1);
            TestOutput output = new TestOutput();

            GuessTheNamberGame game = new GuessTheNamberGame(10, 100, input, output, generator);
                      

            //verifico che alla decima volta dia lose
            Assert.AreEqual(GameStatus.LOSE, output.lastGameStatus);
        }

    }
}