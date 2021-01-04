using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public class Player
    {
        private string _name;
        private Choice _choice;
        private int _won, _lost, _streak, _highestStreak, _score, _roundsPlayed;

        public Choice Choice { get { return _choice; } set { _choice = value; } }

        public string Name { get { return _name; } private set { } }

        public int Won { get { return _won; } private set { } }

        public int Lost { get { return _lost; } private set { } }

        public int Streak { get { return _streak; } private set { } }

        public int HighestStreak { get { return _highestStreak; } private set { } }

        public int Score { get { return _score; } private set { } }

        public int RoundsPlayed { get { return _roundsPlayed; } private set { } }

        public Player(string name)
        {
            _name = name;
            _won = 0;
            _lost = 0;
            _streak = 0;
            _score = 0;
        }

        public void IncrementStreak()
        {
            _streak += 1;

            if (_streak > _highestStreak)
            {
                _highestStreak = _streak;
            }
        }

        public void IncrementScore()
        {
            int streak = _streak;

            if (streak == 0)
            {
                streak = 1;
            }

            _score += (1 * streak);
        }

        public void IncrementWon() => _won += 1;

        public void IncrementLost() => _lost += 1;

        public void ResetStreak() => _streak = 0;

        public void IncrementRoundsPlayed() => _roundsPlayed += 1;
    }
}