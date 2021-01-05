using NUnit.Framework;
using RockPaperScissorsGame;

namespace RockPaperScissorsTESTS
{
    public class PlayerChoiceTests
    {
        GameLoop gl = new GameLoop();

        [Test]
        public void GivenPlayerRockIsCalled_ThePlayerChoiceChangesToMatch()
        {
            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            gl.PlayerRock();

            Assert.That(gl.HumanPlayer.Choice, Is.InstanceOf<Rock>());
        }

        [Test]
        public void GivenPlayerPaperIsCalled_ThePlayerChoiceChangesToMatch()
        {
            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            gl.PlayerPaper();

            Assert.That(gl.HumanPlayer.Choice, Is.InstanceOf<Paper>());
        }

        [Test]
        public void GivenPlayerScissorsIsCalled_ThePlayerChoiceChangesToMatch()
        {
            gl.HumanPlayer = new Player("Human Player");
            gl.ComputerPlayer = new Player("Computer");

            gl.PlayerScissors();

            Assert.That(gl.HumanPlayer.Choice, Is.InstanceOf<Scissors>());
        }
    }
}
