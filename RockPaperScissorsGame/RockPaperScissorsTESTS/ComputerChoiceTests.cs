using NUnit.Framework;
using RockPaperScissorsGame;
using Moq;

namespace RockPaperScissorsTESTS
{
    public class ComputerChoiceTests
    {
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(33)]
        public void WhenARandomNumberWithinTheRockRangeIsGenerated_TheComputersChoiceWillBeRock(int generatedNumber)
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(generatedNumber);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.HumanPlayer.Choice = new Rock(gl.HumanPlayer);

            gl.ComputerPlayer = new Player("Computer");

            gl.ComputerChoice(gl.ComputerPlayer);

            Assert.That(gl.ComputerPlayer.Choice, Is.InstanceOf<Rock>());
        }

        [TestCase(34)]
        [TestCase(45)]
        [TestCase(66)]
        public void WhenARandomNumberWithinThePaperRangeIsGenerated_TheComputersChoiceWillBePaper(int generatedNumber)
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(generatedNumber);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.HumanPlayer.Choice = new Rock(gl.HumanPlayer);

            gl.ComputerPlayer = new Player("Computer");

            gl.ComputerChoice(gl.ComputerPlayer);

            Assert.That(gl.ComputerPlayer.Choice, Is.InstanceOf<Paper>());
        }

        [TestCase(67)]
        [TestCase(84)]
        [TestCase(99)]
        public void WhenARandomNumberWithinTheScissorsRangeIsGenerated_TheComputersChoiceWillBeScissors(int generatedNumber)
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(generatedNumber);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.HumanPlayer.Choice = new Rock(gl.HumanPlayer);

            gl.ComputerPlayer = new Player("Computer");

            gl.ComputerChoice(gl.ComputerPlayer);

            Assert.That(gl.ComputerPlayer.Choice, Is.InstanceOf<Scissors>());
        }

        [TestCase(13, "Draw")]//Computer picks Rock, player picks Rock
        [TestCase(45, "Win")]//Computer picks Paper, player picks Rock
        [TestCase(84, "Loss")]//Computer picks Scissors, player picks Rock
        public void WhenThePlayerPicksRock_ComputerChoiceWillOutputTheCorrectResult(int generatedNumber, string expected)
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(generatedNumber);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.HumanPlayer.Choice = new Rock(gl.HumanPlayer);

            gl.ComputerPlayer = new Player("Computer");

            string result = gl.ComputerChoice(gl.ComputerPlayer);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(13, "Loss")]//Computer picks Rock, player picks Paper
        [TestCase(45, "Draw")]//Computer picks Paper, player picks Paper
        [TestCase(84, "Win")]//Computer picks Scissors, player picks Paper
        public void WhenThePlayerPicksPaper_ComputerChoiceWillOutputTheCorrectResult(int generatedNumber, string expected)
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(generatedNumber);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.HumanPlayer.Choice = new Paper(gl.HumanPlayer);

            gl.ComputerPlayer = new Player("Computer");

            string result = gl.ComputerChoice(gl.ComputerPlayer);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(13, "Win")]//Computer picks Rock, player picks Scissors
        [TestCase(45, "Loss")]//Computer picks Paper, player picks Scissors
        [TestCase(84, "Draw")]//Computer picks Scissors, player picks Scissors
        public void WhenThePlayerPicksScissors_ComputerChoiceWillOutputTheCorrectResult(int generatedNumber, string expected)
        {
            Mock<IRandomNumber> mockRandomNumber = new Mock<IRandomNumber>();
            mockRandomNumber.Setup(x => x.GenerateRandomInt(1, 100)).Returns(generatedNumber);

            GameLoop gl = new GameLoop(mockRandomNumber.Object);

            gl.HumanPlayer = new Player("Human Player");
            gl.HumanPlayer.Choice = new Scissors(gl.HumanPlayer);

            gl.ComputerPlayer = new Player("Computer");

            string result = gl.ComputerChoice(gl.ComputerPlayer);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
