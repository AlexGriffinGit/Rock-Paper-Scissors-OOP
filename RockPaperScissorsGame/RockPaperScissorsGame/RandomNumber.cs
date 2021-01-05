using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    class RandomNumber : IRandomNumber
    {
        Random _rand = new Random();

        public int GenerateRandomInt(int lowerLimit, int highLimit)
        {
            return _rand.Next(1, 100);
        }
    }
}
