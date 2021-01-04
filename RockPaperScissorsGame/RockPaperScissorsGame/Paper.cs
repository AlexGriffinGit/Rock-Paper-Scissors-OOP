using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public class Paper : Choice
    {
        private string _name;
        private Player _player;
        private Rock _beats;
        private Scissors _loses;

        public Paper(Player player, Rock beats, Scissors loses) : base(player, beats, loses)
        {
            _name = "Paper";
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
