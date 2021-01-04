using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsGame
{
    public class Player
    {
        private string _name;
        private Choice _choice;
        private int _won;
        private int _lost;
        private int _streak;
        private int _highestStreak;
        private int _score;

        public Choice Choice 
        {
            get { return _choice; }
            set { _choice = Choice; }
        }

        public string Name
        {
            get { return _name; }
            private set { }
        }

        public int Won 
        { 
            get { return _won; }
            private set { }
        }

        public int Lost
        {
            get { return _lost; }
            private set { }
        }

        public int Streak
        {
            get { return _streak; }
            private set { }
        }

        public int HighestStreak
        {
            get { return _highestStreak; }
            private set { }
        }

        public int Score
        {
            get { return _score; }
            private set { }
        }

        public Player(string name)
        {
            _name = name;
            _won = 0;
            _lost = 0;
            _streak = 0;
            _score = 0;
        }

        public void IncrementWon()
        {
            _won = _won + 1;
        }

        public void IncrementLost()
        {
            _lost = _lost + 1;
        }

        public void IncrementStreak()
        {
            _streak = _streak + 1;

            if (_streak > _highestStreak)
            {
                _highestStreak = _streak;
            }
        }

        public void ResetStreak()
        {
            _streak = 0;
        }

        public void IncrementScore()
        {
            int streak = _streak;

            if (streak == 0)
            {
                streak = 1;
            }

            _score = _score + (1 * streak);
        }
    }
}
