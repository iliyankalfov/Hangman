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
        /*[Fact]
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

        [Theory]
        [InlineData("re","rescore","_______")]
        [InlineData("sc","scope","_____")]
        public void FillingTheGuessingWordWithTwoOrMoreLetters(string letter,string word,string expected)
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter(letter);

            Assert.Equal(expected, gameEngine.guessingWord);
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

            Assert.Throws<ArgumentException>(() => gameEngine.GuessingLetter(""));
        }

        [Fact]
        public void FillingTheGuessingWordWithASameLetter()
        {
            GameTracker gameTracker = new GameTracker();
            Game gameEngine = new Game(gameTracker);
            string word = "rescore";
            var expectedFailsLeft = 8;

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter("e");
            gameEngine.GuessingLetter("e");

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
            var expectedFails = 9;
            var expectedJokers = 1;

            gameEngine.InitializingWord(word);
            gameEngine.GuessingLetter("s");
            gameEngine.GuessingLetter("c");
            gameEngine.gameTracker.ResetScore();

            Assert.Equal(expectedFails, gameEngine.gameTracker.Fails);
            Assert.Equal(expectedJokers, gameEngine.gameTracker.Joker);
        }*/
    }
}
