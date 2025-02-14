namespace LibraryProject
{

    public class GuessTheNamberGame
    {
        //impostazioni del gioco         
        private int _maxAttempts;
        private int _usedAttempts;
        private int _numberToGuess;
        private GameStatus _status;        
        
        private IInputInterface _input;
        private IOutputInterface _output;

        //salviamo la lista dei tentativi per usi
        private List<int> _allAttempts;
        public List<int> AllAttempts { get { return _allAttempts; } }
        public int RemainingAttempts
        {
            get { return _maxAttempts - _usedAttempts; }
        }

        public GuessTheNamberGame(int maxAttempts, int maxNumber, IInputInterface input, IOutputInterface output,INumberGenerator? generator = null)
        {
            if(maxAttempts<=0 || maxNumber<1) throw new ArgumentOutOfRangeException();
            _maxAttempts = maxAttempts;
            _usedAttempts = 0;
            _allAttempts = new List<int>();

            //di default generatore di numeri random
            if (generator == null) { generator = new RandomGenerator(); }
            //richiamo la generazione del numero da indovinare (come avviene questa generazione sarà definito dal tipo di generator che abbiamo
            _numberToGuess = generator.GenerateNumber(maxNumber);

            //imposto le interacce di input ed output attraverso le quali ricevere i dati e visualizzare i risultati
            _input = input;
            _output = output;

            //Facciamo iniziale il gioco
            _status = GameStatus.IN_PROGRESS;
            Play();
        }

        //il metodo deve essere asincrono (async) per poter usare il task per l'input ed attendere senza bloccare tutto
        private async void Play()
        {
            while (_status == GameStatus.IN_PROGRESS)
            {
                //ricevo il tentativo in input
                int number = await _input.InputAttempt();

                //controllo il tentativo
                AttemptResult result = Attempt(number);

                //invio gli stati per l'output
                _output.OutputAttemptResult(result);
                _output.OutputGameStatus(_status);
            } 
            
        }

        private AttemptResult Attempt(int attempt)
        {
            AttemptResult result;
            _usedAttempts += 1;
            _allAttempts.Add(attempt);

            if (attempt == _numberToGuess)
            {
                _status = GameStatus.WIN;
                result = AttemptResult.GUESSED;
            }
            else
            {
                if (attempt < _numberToGuess)                
                    result = AttemptResult.TOO_LITTLE;                
                else
                    result = AttemptResult.TOO_BIG;

                if (RemainingAttempts > 0)
                    _status = GameStatus.IN_PROGRESS;
                else
                    _status = GameStatus.LOSE;
            }
            
            return result;
        }

    }
}
