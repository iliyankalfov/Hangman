using GameLogic;
using Hangman.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hangman.Tests.GameTests
{
    public class GameTests
    {
        [Fact]
        public void InitializingOfTheWord()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "ball";
            string guessingWord = new string('_', word.Length);

            gameEngine.InitializingWord(word);

            Assert.Equal(word, gameEngine.realWord);
            Assert.Equal(guessingWord, gameEngine.guessingWord);
        }

        [Fact]
        public void FillingTheGuessingWordWithTwoOrMoreLetters()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "rescore";

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter("re");
            gameEngine.GuessingLetter("res");
            gameEngine.GuessingLetter("sco");

            var expectedFailsLeft = 6; 
            Assert.Equal(expectedFailsLeft, gameEngine.gameTracker.Fails);
        }

        [Fact]
        public void FillingTheGuessingWordWithValidLetter()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "revenue";
            string letter = "e";

            gameEngine.InitializingWord(word);
            
            gameEngine.GuessingLetter(letter);
            Assert.Equal("_e_e__e", gameEngine.guessingWord);
        }

        [Fact]
        public void FillingTheGuessingWordWithNoData()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "rescore";

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter("");

            var expectedFailsLeft = 9;
            Assert.Equal(expectedFailsLeft, gameEngine.gameTracker.Fails);
        }

        [Fact]
        public void FillingTheGuessingWordWithASameLetter()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "rescore";

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter("e");
            gameEngine.GuessingLetter("e");

            var expectedFailsLeft = 8;
            Assert.Equal(expectedFailsLeft, gameEngine.gameTracker.Fails);
        }

        [Fact]
        public void TestingTheJokerWithMinPriority()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "rescore";

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter("s");
            gameEngine.GuessingLetter("c");
            gameEngine.UseJoker();

            Assert.Equal("__sco__", gameEngine.guessingWord);
        }

        [Fact]
        public void TestingResetScore()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "rescore";

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter("s");
            gameEngine.GuessingLetter("c");
            gameEngine.gameTracker.ResetScore();

            var expectedFails = 9;
            var expectedJokers = 1;
            Assert.Equal(expectedFails, gameEngine.gameTracker.Fails);
            Assert.Equal(expectedJokers, gameEngine.gameTracker.Joker);
        }
    }
}
