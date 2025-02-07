namespace CoreLibrary
{
    public enum GameStatus
    {
        LOSE,
        WIN,
        IN_PROGRESS
    }
    public class Game
    {
        private int _maxAttempts;
        private int _usedAttempts;

        private int _numberToGuess;
        private GameStatus _status;
        public GameStatus Status { get { return _status; } }

        public int RemainingAttempts
        {
            get { return _maxAttempts - _usedAttempts; }
        }

        public Game(int maxAttempts=10, int maxNumeber=1000)
        {
            this._maxAttempts = maxAttempts;
            this._usedAttempts = 0;

            Random random = new Random();
            this._numberToGuess = random.Next(maxNumeber);

            _status = GameStatus.IN_PROGRESS;
        }

        public GameStatus Attempts(int attempts)
        {
            _usedAttempts += 1;
            if(attempts == _numberToGuess)
            {
                _status = GameStatus.WIN;
            }
            if(RemainingAttempts>0)
                _status = GameStatus.IN_PROGRESS; 
            else
                _status = GameStatus.LOSE;

            return Status;
        }

    }
}
