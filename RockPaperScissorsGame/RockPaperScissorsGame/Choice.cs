using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public abstract class Choice
    {
        private string _name;
        private Player _player;
        private Choice _beats;
        private Choice _loses;

        public Choice(Player player, Choice beats, Choice loses)
        {
            _name = "Choice";
            _player = player;
            _beats = beats;
            _loses = loses;
        }

        public override string ToString()
        {
            return $"{ _player } has chosen { _name } which beats { _beats } but loses to { _loses }";
        }
    }
}
