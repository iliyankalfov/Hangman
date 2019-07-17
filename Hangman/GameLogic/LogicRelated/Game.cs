using Hangman.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    public class Game : IGame
    {
        public Game(GameTracker tracker)
        {
            this.gameTracker = tracker;
        }

        public string realWord { get; private set; }

        public string guessingWord { get; private set; }

        public GameTracker gameTracker { get; }

        public void InitializingWord(string realWord)
        {
            this.realWord = realWord;
            this.guessingWord = new string('_', realWord.Length);
        }

        public void UseJoker()
        {
            string randomLetter = LetterWithMinPriority();

            GuessingLetter(randomLetter);
            this.gameTracker.Joker--;
            
        }

        public void Check(string letter)
        {
            if (letter.Length > 1)
            {
                this.gameTracker.Fails--;
            }
            else if (letter == null)
            {
                throw new ArgumentException("Letter should be provided!");
            }
        }
        public void GuessingLetter(string letter)
        {
            if(letter.Length == 1)
            {
                string firstWord = this.guessingWord;

                for (int i = 0; i < this.realWord.Length; i++)
                {
                    if(this.realWord[i].ToString()==letter)
                    {
                        this.guessingWord = this.guessingWord.Substring(0, i) + letter
                            + this.guessingWord.Substring(i + 1);
                    }
                }
                if(firstWord == this.guessingWord)
                {
                    this.gameTracker.Fails--;
                }
            }
            Check(letter);
        }

        public string LetterWithMinPriority()
        {
            Dictionary<string, int> letterWithPriority = new Dictionary<string, int>();
            for (int i = 0; i < guessingWord.Length; i++)
            {
                if (guessingWord[i] == '_')
                {
                    string letter = realWord[i].ToString();
                    if (letterWithPriority.ContainsKey(letter))
                    {
                        letterWithPriority[letter]++;
                    }
                    else
                    {
                        letterWithPriority.Add(letter, 0);
                    }

                }
            }
            Random rnd = new Random();
            return letterWithPriority.OrderBy(v => v.Value)
                .ThenBy(r => rnd.Next()).First().Key ;
        }
        
    }
}
