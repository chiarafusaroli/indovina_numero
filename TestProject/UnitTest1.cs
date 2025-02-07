namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        /*
         * Questo progetto è molto semplice ma non è testabile, perchè il nuemro da indovinare è random 
         * e correttamente non accessibile all'esterno della classe Game, quindi la sola cosa che potremmo 
         * fare è quella di verificare che non vengano superati i tentativi
         * In generale questo è un grosso problema per i progetti.
         * Per risolvere questi problemi bisogna inserire l'uso delle interfacce
         */
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}