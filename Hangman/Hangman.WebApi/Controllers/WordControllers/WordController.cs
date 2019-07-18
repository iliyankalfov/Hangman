using Hangman.Data.Models;
using Hangman.Data.Models.Enums;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.WebApi.Controllers
{
    public class WordController : ApiController
    {
        private readonly IWordService wordService;

        public WordController(IWordService wordService)
        {
            this.wordService = wordService;
        }

        [HttpGet("{wordDifficulty}/{categoryId}")]
        public ActionResult<string> GetRandomWord(WordDifficulty wordDifficulty, int categoryId)
        {
            var word = wordService.GetRandomWord(wordDifficulty,categoryId);
            return word;
        }

        [HttpGet]
        public ActionResult<List<Word>> GetAllWords()
        {
            var words = wordService.GetAllWords();
            return words;
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<int> GetWordIdWithGivenName(string name)
        {
            var wordId = wordService.GetWordIdWithGivenName(name);
            return wordId;
        }

        [HttpGet("[action]/{wordId}")]
        public ActionResult<WordDifficulty> GetWordDifficultyWithGivenWordId(int wordId)
        {
            var wordDifficulty = wordService.GetWordDifficultyWithGivenWordId(wordId);
            return wordDifficulty;
        }

        /*[HttpDelete]
        public ActionResult DeleteAllWords()
        {
            wordService.DeleteAllWords();
            return this.Ok();
        }*/

        /*[HttpPost]
        public ActionResult CreateWords()
        {
            wordService.CreateWords();
            return this.Ok();
        }*/

        [HttpGet("{id}")]
        public ActionResult<string> GetWordWithGivenId(int id)
        {
            return wordService.GetWordWithGivenId(id);
        }

        //Personal stats(in progress)
        /*[HttpGet("[action]/{wordDifficulty}/{categoryId}")]
        public ActionResult<List<Word>> GetAllWordsWithGivenDifficultyAndCategoryId(WordDifficulty wordDifficulty, int categoryId)
        {
            return wordService.GetAllWordsWithGivenDifficultyAndCategoryId(wordDifficulty, categoryId);
        }*/
    }
}
