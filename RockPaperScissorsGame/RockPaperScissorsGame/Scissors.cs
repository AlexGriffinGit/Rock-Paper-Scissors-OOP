using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public class Scissors : Choice
    {
        private string _name;
        private Player _player;
        private Player _opponent;

        public Scissors(Player player, Player opponent) : base(player, opponent)
        {
            _name = "Scissors";
            _player = player;
            _opponent = opponent;
        }

        public Scissors(Player player) : base(player)
        {
            _name = "Scissors";
            _player = player;
        }

        public override string ToString()
        {
            return $"pair of { _name }";
        }

        public override string Result()
        {
            Type opponentChoice = _opponent.Choice.GetType();

            if (opponentChoice == this.GetType())
            {
                return "Draw";
            }
            else if (opponentChoice.Equals(typeof(Paper)))
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
