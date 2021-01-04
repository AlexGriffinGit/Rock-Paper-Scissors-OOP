using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public class Rock : Choice
    {
        private string _name;
        private Player _player;
        private Player _opponent;

        public Rock(Player player, Player opponent) : base(player, opponent)
        {
            _name = "Rock";
            _player = player;
            _opponent = opponent;
        }

        public Rock(Player player) : base(player)
        {
            _name = "Rock";
            _player = player;
        }

        public override string ToString()
        {
            return $"{ _player.Name } has chosen Rock which beats Scissors but loses to Paper";
        }

        public override string Result()
        {
            Type opponentChoice = _opponent.Choice.GetType();

            if (opponentChoice == this.GetType())
            {
                return "Draw";
            }
            else if (opponentChoice.Equals(typeof(Scissors)))
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
