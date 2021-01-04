using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public class Scissors : Choice
    {
        private string _name;
        private Player _player;
        private Scissors _beats;
        private Paper _loses;

        public Scissors(Player player, Scissors beats, Paper loses) : base(player, beats, loses)
        {
            _name = "Scissors";
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
