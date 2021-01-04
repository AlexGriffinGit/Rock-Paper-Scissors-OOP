using System;

namespace RockPaperScissorsGame
{
    public class GameLoop
    {
        Player humanPlayer;
        Player computer;

        Random rand = new Random();

        public void StartUp(string name)
        {
            if (name == "")
            {
                humanPlayer = new Player("NoName McGee");
            }
            else
            {
                humanPlayer = new Player(name);
            }

            computer = new Player("Computer");
        }

        public void Play()
        {
            string result = ComputerChoice(computer);

            if (result == "Win")
            {
                computer.IncrementWon();
                computer.IncrementStreak();
                computer.IncrementScore();
                humanPlayer.IncrementLost();
                humanPlayer.ResetStreak();
            }
            else if (result == "Loss")
            {
                humanPlayer.IncrementWon();
                humanPlayer.IncrementStreak();
                humanPlayer.IncrementScore();
                computer.IncrementLost();
                computer.ResetStreak();
            }

            computer.IncrementRoundsPlayed();
            humanPlayer.IncrementRoundsPlayed();
        }

        public void PlayerRock()
        {
            humanPlayer.Choice = new Rock(humanPlayer);

            Play();
        }

        public void PlayerPaper()
        {
            humanPlayer.Choice = new Paper(humanPlayer);

            Play();
        }

        public void PlayerScissors()
        {
            humanPlayer.Choice = new Scissors(humanPlayer);

            Play();
        }

        public string ComputerChoice(Player computer)
        {
            int randomNumber = rand.Next(1, 100);

            if (randomNumber >= 1 && randomNumber <= 33)
            {
                computer.Choice = new Rock(computer, humanPlayer);
            }
            else if (randomNumber >= 34 && randomNumber <= 66)
            {
                computer.Choice = new Paper(computer, humanPlayer);
            }
            else
            {
                computer.Choice = new Scissors(computer, humanPlayer);
            }

            return computer.Choice.Result();
        }
    }
}
