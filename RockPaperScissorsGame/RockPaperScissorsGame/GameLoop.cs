using System;

namespace RockPaperScissorsGame
{
    public class GameLoop
    {
        Player _humanPlayer;
        Player _computer;

        public Player HumanPlayer { get { return _humanPlayer; }  set { _humanPlayer = value; } }
        public Player ComputerPlayer { get { return _computer; }  set { _computer = value; } }
        public int GamesDrawn { get { return _gamesDrawn; } private set { } }
        public string ResultString { get { return _resultString; } private set { } }

        int _gamesDrawn = 0;

        string _resultString = "";

        private readonly IRandomNumber _generator;

        public GameLoop(IRandomNumber generator)
        {
            _generator = generator;
        }

        public GameLoop() : this(new RandomNumber())
        {

        }

        public void StartUp(string name)
        {
            if (name == "" || name == "NAME HERE")
            {
                _humanPlayer = new Player("NoName McGee");
            }
            else
            {
                _humanPlayer = new Player(name);
            }

            _computer = new Player("COMPUTER");
        }

        public void Play()
        {
            string _result = ComputerChoice(_computer);

            if (_result == "Win")
            {
                _computer.IncrementWon();
                _computer.IncrementStreak();
                _computer.IncrementScore();
                _humanPlayer.IncrementLost();
                _humanPlayer.ResetStreak();

                _resultString = $"HAHA I WON A GAME, I MEAN I BEAT YOU REAL EASY, YOUR { _humanPlayer.Choice.ToString().ToUpper() } WAS NO MATCH FOR MY { _computer.Choice.ToString().ToUpper() }";
            }
            else if (_result == "Loss")
            {
                _humanPlayer.IncrementWon();
                _humanPlayer.IncrementStreak();
                _humanPlayer.IncrementScore();
                _computer.IncrementLost();
                _computer.ResetStreak();

                _resultString = $"YOU GOT ME REAL GOOD THERE CHAMP, YOUR { _humanPlayer.Choice.ToString().ToUpper() } WAS TOO POWERFUL FOR MY PUNY { _computer.Choice.ToString().ToUpper() }";
            }
            else
            {
                _gamesDrawn++;
                _resultString = $"IT SEEMS GREAT MINDS THINK ALIKE, WE'VE BOTH CHOSEN THE SAME, TAKE YOUR { _humanPlayer.Choice.ToString().ToUpper() } AND DUEL ME AGAIN MON FRÈRE";
            }

            _computer.IncrementRoundsPlayed();
            _humanPlayer.IncrementRoundsPlayed();
        }

        public void PlayerRock()
        {
            _humanPlayer.Choice = new Rock(_humanPlayer);

            Play();
        }

        public void PlayerPaper()
        {
            _humanPlayer.Choice = new Paper(_humanPlayer);

            Play();
        }

        public void PlayerScissors()
        {
            _humanPlayer.Choice = new Scissors(_humanPlayer);

            Play();
        }

        public string ComputerChoice(Player computer)
        {
            int _randomNumber = _generator.GenerateRandomInt(1, 100);

            if (_randomNumber >= 1 && _randomNumber <= 33)
            {
                computer.Choice = new Rock(computer, _humanPlayer);
            }
            else if (_randomNumber >= 34 && _randomNumber <= 66)
            {
                computer.Choice = new Paper(computer, _humanPlayer);
            }
            else
            {
                computer.Choice = new Scissors(computer, _humanPlayer);
            }

            return computer.Choice.Result();
        }
    }
}
