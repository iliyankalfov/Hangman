using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.GameLogic
{
    public class GameTracker
    {
        private const int MAX_FAILS = 9;
        private const int MAX_JOKERS = 1;

        public int Joker { get; set; } = MAX_JOKERS;

        //public event Action StateChange;
        public int Fails { get; set; } = MAX_FAILS;

        public bool GameOver()
        {
            if (this.Fails == 0)
            {
                return true;
            }
            else return false;          
        }
        public bool NoAvailableJokers()
        {
            if (this.Joker == 0)
            {
                return true;
            }
            else return false;
        }
        public void ResetScore()
        {
            this.Fails = MAX_FAILS;
            this.Joker = MAX_JOKERS;
        }

    }
}
