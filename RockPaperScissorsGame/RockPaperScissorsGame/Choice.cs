using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public abstract class Choice
    {
        private string _name;
        private Player _player;
        private Player _opponent;
        private Choice _beats;
        private Choice _loses;

        public Choice(Player player, Player opponent)
        {
            _name = "Choice";
            _player = player;
            _opponent = opponent;
        }

        public Choice(Player player)
        {
            _name = "Choice";
            _player = player;
        }

        public override string ToString()
        {
            return $"{ _player.Name } has chosen { _name } which beats { _beats } but loses to { _loses }";
        }

        public abstract string Result();

    }
}
