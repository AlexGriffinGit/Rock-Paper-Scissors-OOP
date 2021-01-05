using NUnit.Framework;
using RockPaperScissorsGame;

namespace RockPaperScissorsTESTS
{
    public class PlayerNameTests
    {
        GameLoop gl = new GameLoop();

        [Test]
        public void LeavingNameText_GivesThePlayerTheDefaultName()
        {
            gl.StartUp("NAME HERE");

            Assert.That(gl.HumanPlayer.Name, Is.EqualTo("NoName McGee"));
        }

        [Test]
        public void LeavingNameBlank_GivesThePlayerTheDefaultName()
        {
            gl.StartUp("");

            Assert.That(gl.HumanPlayer.Name, Is.EqualTo("NoName McGee"));
        }

        [TestCase("Cave Johnson")]
        [TestCase("Sarah Smith")]
        [TestCase("1 Lik3 Numb3rs")]
        [TestCase("!!! ??? @@@ ###")]
        public void EnteringNames_GivesThePlayerTheCorrectName(string name)
        {
            gl.StartUp(name);

            Assert.That(gl.HumanPlayer.Name, Is.EqualTo(name));
        }

        [Test]
        public void OnStartUp_GivesTheComputerTheCorrectName()
        {
            gl.StartUp("");

            Assert.That(gl.ComputerPlayer.Name, Is.EqualTo("COMPUTER"));
        }
    }
}