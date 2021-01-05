using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public interface IRandomNumber
    {
        int GenerateRandomInt(int lowerLimit, int highLimit);
    }
}
