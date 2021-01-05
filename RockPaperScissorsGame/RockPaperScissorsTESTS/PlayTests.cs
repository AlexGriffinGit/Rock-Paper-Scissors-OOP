using NUnit.Framework;
using RockPaperScissorsGame;
using Moq;

namespace RockPaperScissorsTESTS
{
    public class PlayTests
    {
        [Test]
        public void GivenTheComputerWinsARound_TheCorrectCountersAreIncremented()
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(15);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            int computerWins = gl.ComputerPlayer.Won;
            int computerLost = gl.ComputerPlayer.Lost;
            int computerStreak = gl.ComputerPlayer.Streak;
            int computerHighStreak = gl.ComputerPlayer.HighestStreak;
            int computerScore = gl.ComputerPlayer.Score;

            int playerWins = gl.HumanPlayer.Won;
            int playerLost = gl.HumanPlayer.Lost;
            int playerScore = gl.HumanPlayer.Score;
            int playerStreak = gl.HumanPlayer.Streak;

            int gamesPlayed = gl.ComputerPlayer.RoundsPlayed;
            int roundsDrawn = gl.GamesDrawn;

            gl.HumanPlayer.Choice = new Scissors(gl.HumanPlayer);

            gl.Play();

            Assert.That(gl.ComputerPlayer.Won, Is.EqualTo(computerWins + 1));
            Assert.That(gl.ComputerPlayer.Lost, Is.EqualTo(computerLost));
            Assert.That(gl.ComputerPlayer.Streak, Is.EqualTo(computerStreak + 1));
            Assert.That(gl.ComputerPlayer.HighestStreak, Is.EqualTo(computerHighStreak + 1));
            Assert.That(gl.ComputerPlayer.Score, Is.EqualTo(computerScore + 1));

            Assert.That(gl.HumanPlayer.Won, Is.EqualTo(playerWins));
            Assert.That(gl.HumanPlayer.Lost, Is.EqualTo(playerLost + 1));
            Assert.That(gl.HumanPlayer.Score, Is.EqualTo(playerScore));
            Assert.That(gl.HumanPlayer.Streak, Is.EqualTo(playerStreak));

            Assert.That(gl.ComputerPlayer.RoundsPlayed, Is.EqualTo(gamesPlayed + 1));
            Assert.That(gl.GamesDrawn, Is.EqualTo(roundsDrawn));
        }

        [Test]
        public void GivenTheHumanWinsARound_TheCorrectCountersAreIncremented()
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(45);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            int playerWins = gl.HumanPlayer.Won;
            int playerLost = gl.HumanPlayer.Lost;
            int playerStreak = gl.HumanPlayer.Streak;
            int playerHighStreak = gl.HumanPlayer.HighestStreak;
            int playerScore = gl.HumanPlayer.Score;

            int computerWins = gl.ComputerPlayer.Won;
            int computerLost = gl.ComputerPlayer.Lost;
            int computerScore = gl.ComputerPlayer.Score;
            int computerStreak = gl.ComputerPlayer.Streak;

            int gamesPlayed = gl.HumanPlayer.RoundsPlayed;
            int roundsDrawn = gl.GamesDrawn;

            gl.HumanPlayer.Choice = new Scissors(gl.HumanPlayer);

            gl.Play();

            Assert.That(gl.HumanPlayer.Won, Is.EqualTo(playerWins + 1));
            Assert.That(gl.HumanPlayer.Lost, Is.EqualTo(playerLost));
            Assert.That(gl.HumanPlayer.Streak, Is.EqualTo(playerStreak + 1));
            Assert.That(gl.HumanPlayer.HighestStreak, Is.EqualTo(playerHighStreak + 1));
            Assert.That(gl.HumanPlayer.Score, Is.EqualTo(playerScore + 1));

            Assert.That(gl.ComputerPlayer.Won, Is.EqualTo(computerWins));
            Assert.That(gl.ComputerPlayer.Lost, Is.EqualTo(computerLost + 1));
            Assert.That(gl.ComputerPlayer.Score, Is.EqualTo(computerScore));
            Assert.That(gl.ComputerPlayer.Streak, Is.EqualTo(computerStreak));

            Assert.That(gl.HumanPlayer.RoundsPlayed, Is.EqualTo(gamesPlayed + 1));
            Assert.That(gl.GamesDrawn, Is.EqualTo(roundsDrawn));
        }

        [Test]
        public void GivenTheRoundIsADraw_TheCorrectCountersAreIncremented()
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(45);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            int playerWins = gl.HumanPlayer.Won;
            int playerLost = gl.HumanPlayer.Lost;
            int playerStreak = gl.HumanPlayer.Streak;
            int playerHighStreak = gl.HumanPlayer.HighestStreak;
            int playerScore = gl.HumanPlayer.Score;

            int computerWins = gl.ComputerPlayer.Won;
            int computerLost = gl.ComputerPlayer.Lost;
            int computerStreak = gl.ComputerPlayer.Streak;
            int computerHighStreak = gl.ComputerPlayer.HighestStreak;
            int computerScore = gl.ComputerPlayer.Score;

            int gamesPlayed = gl.HumanPlayer.RoundsPlayed;
            int roundsDrawn = gl.GamesDrawn;

            gl.HumanPlayer.Choice = new Paper(gl.HumanPlayer);

            gl.Play();

            Assert.That(gl.HumanPlayer.Won, Is.EqualTo(playerWins));
            Assert.That(gl.HumanPlayer.Lost, Is.EqualTo(playerLost));
            Assert.That(gl.HumanPlayer.Streak, Is.EqualTo(playerStreak));
            Assert.That(gl.HumanPlayer.HighestStreak, Is.EqualTo(playerHighStreak));
            Assert.That(gl.HumanPlayer.Score, Is.EqualTo(playerScore));

            Assert.That(gl.ComputerPlayer.Won, Is.EqualTo(computerWins));
            Assert.That(gl.ComputerPlayer.Lost, Is.EqualTo(computerLost));
            Assert.That(gl.ComputerPlayer.Streak, Is.EqualTo(computerStreak));
            Assert.That(gl.ComputerPlayer.HighestStreak, Is.EqualTo(computerHighStreak));
            Assert.That(gl.ComputerPlayer.Score, Is.EqualTo(computerScore));

            Assert.That(gl.HumanPlayer.RoundsPlayed, Is.EqualTo(gamesPlayed + 1));
            Assert.That(gl.GamesDrawn, Is.EqualTo(roundsDrawn + 1));
        }

        [Test]
        public void GivenTheComputerWinsMultipleRounds_TheirStreakIsProperlyRecorded()
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(15);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            int computerWins = gl.ComputerPlayer.Won;
            int computerStreak = gl.ComputerPlayer.Streak;
            int computerHighStreak = gl.ComputerPlayer.HighestStreak;

            gl.HumanPlayer.Choice = new Scissors(gl.HumanPlayer);

            gl.Play();
            gl.Play();
            gl.Play();
            gl.Play();

            Assert.That(gl.ComputerPlayer.Won, Is.EqualTo(computerWins + 4));
            Assert.That(gl.ComputerPlayer.Streak, Is.EqualTo(computerStreak + 4));
            Assert.That(gl.ComputerPlayer.HighestStreak, Is.EqualTo(computerHighStreak + 4));
        }

        [Test]
        public void GivenTheComputerWinsMultipleRoundsAndThenLosesOne_TheirStreakIsResetAndTheirHighestIsRecorded()
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(15);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            int computerWins = gl.ComputerPlayer.Won;
            int computerStreak = gl.ComputerPlayer.Streak;
            int computerHighStreak = gl.ComputerPlayer.HighestStreak;

            gl.HumanPlayer.Choice = new Scissors(gl.HumanPlayer);

            gl.Play();
            gl.Play();
            gl.Play();
            gl.HumanPlayer.Choice = new Paper(gl.HumanPlayer);
            gl.Play();

            Assert.That(gl.ComputerPlayer.Won, Is.EqualTo(computerWins + 3));
            Assert.That(gl.ComputerPlayer.Streak, Is.EqualTo(computerStreak));
            Assert.That(gl.ComputerPlayer.HighestStreak, Is.EqualTo(computerHighStreak + 3));
        }

        [Test]
        public void GivenTheComputerWinsMultipleRoundsAndThenDrawsOne_TheirStreakIsNotBroken()
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(15);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            int computerWins = gl.ComputerPlayer.Won;
            int computerStreak = gl.ComputerPlayer.Streak;
            int computerHighStreak = gl.ComputerPlayer.HighestStreak;

            gl.HumanPlayer.Choice = new Scissors(gl.HumanPlayer);

            gl.Play();
            gl.Play();
            gl.Play();
            gl.HumanPlayer.Choice = new Rock(gl.HumanPlayer);
            gl.Play();

            Assert.That(gl.ComputerPlayer.Won, Is.EqualTo(computerWins + 3));
            Assert.That(gl.ComputerPlayer.Streak, Is.EqualTo(computerStreak + 3));
            Assert.That(gl.ComputerPlayer.HighestStreak, Is.EqualTo(computerHighStreak + 3));
        }

        [TestCase(15, "YOU GOT ME REAL GOOD THERE CHAMP, YOUR PAPER WAS TOO POWERFUL FOR MY PUNY ROCK")]
        [TestCase(84, "HAHA I WON A GAME, I MEAN I BEAT YOU REAL EASY, YOUR PAPER WAS NO MATCH FOR MY PAIR OF SCISSORS")]
        [TestCase(45, "IT SEEMS GREAT MINDS THINK ALIKE, WE'VE BOTH CHOSEN THE SAME, TAKE YOUR PAPER AND DUEL ME AGAIN MON FRÈRE")]
        public void GivenARoundIsPlayed_TheResultStringIsCorrect(int randomNunber, string expected)
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(randomNunber);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            gl.HumanPlayer.Choice = new Paper(gl.HumanPlayer);

            gl.Play();

            Assert.That(gl.ResultString, Is.EqualTo(expected));
        }
    }
}
