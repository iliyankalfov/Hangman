using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public interface IGame
    {
        void InitializingWord(string realWord);

        void GuessingLetter(string letter);

        void UseJoker();
    }
}
