using Hangman.Data.Models;
using Hangman.Services.WordCategoryServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.WebApi.Controllers
{
    public class WordCategoryController : ApiController
    {
        private readonly IWordCategoryService wordCategoryService;

        public WordCategoryController(IWordCategoryService wordCategoryService)
        {
            this.wordCategoryService = wordCategoryService;
        }

        [HttpPost("[action]")]
        public ActionResult CreateCategories()
        {
            wordCategoryService.CreateCategories();
            return this.Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetCategoryWithGivenId(int id)
        {
            var wc = wordCategoryService.GetCategoryWithGivenId(id);
            return wc;
        }

        /*[HttpGet]
        public ActionResult<List<WordCategory>> GetCategories()
        {
            var wordCategories = wordCategoryService.GetCategories();
            return wordCategories;
        }*/

        [HttpGet("[action]")]
        public ActionResult<int> GetRandomCategory()
        {
            var category = wordCategoryService.GetRandomCategory();
            return category;
        }
    }
}
