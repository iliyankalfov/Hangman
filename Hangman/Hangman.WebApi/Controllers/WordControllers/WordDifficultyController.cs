using Hangman.Services.WordServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.WebApi.Controllers
{
    public class WordDifficultyController : ApiController
    {
        private readonly IWordDifficultyService wordDifficultyService;

        public WordDifficultyController(IWordDifficultyService wordDifficultyService)
        {
            this.wordDifficultyService = wordDifficultyService;
        }

        [HttpPost]
        public ActionResult CreateWordDifficulties()
        {
            wordDifficultyService.CreateWordDifficulties();
            return this.Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<int> GetWordDifficultyId(int id)
        {
            var wdId = wordDifficultyService.GetWordDifficultyId(id);
            return wdId;
        }
    }
}
