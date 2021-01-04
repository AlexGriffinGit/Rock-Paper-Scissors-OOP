using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public class Paper : Choice
    {
        private string _name;
        private Player _player;
        private Player _opponent;

        public Paper(Player player, Player opponent) : base(player, opponent)
        {
            _name = "Paper";
            _player = player;
            _opponent = opponent;
        }

        public Paper(Player player) : base(player)
        {
            _name = "Paper";
            _player = player;
        }

        public override string ToString()
        {
            return _name;
        }

        public override string Result()
        {
            Type opponentChoice = _opponent.Choice.GetType();

            if (opponentChoice == this.GetType())
            {
                return "Draw";
            }
            else if (opponentChoice.Equals(typeof(Rock)))
            {
                return "Win";
            }
            else
            {
                return "Loss";
            }
        }
    }
}
