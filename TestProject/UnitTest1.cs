namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        /*
         * Questo progetto � molto semplice ma non � testabile, perch� il nuemro da indovinare � random 
         * e correttamente non accessibile all'esterno della classe Game, quindi la sola cosa che potremmo 
         * fare � quella di verificare che non vengano superati i tentativi
         * In generale questo � un grosso problema per i progetti.
         * Per risolvere questi problemi bisogna inserire l'uso delle interfacce
         */
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}