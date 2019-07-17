using Hangman.Data.Models;
using Hangman.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("{email}/{password}")]
        public ActionResult CreateUser(string email, string password)
        {
            userService.CreateUser(email,password);
            return this.Ok();
        }

        /*[HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = userService.GetAllUsers();
            return users;
        }*/

        [HttpDelete]
        public ActionResult DeleteAllUsers()
        {
            userService.DeleteAllUsers();
            return this.Ok();
        }

        [HttpGet("{email}/{password}")]
        public ActionResult<int> GetGetUserIdWithGivenEmail(string email,string password)
        {
            var userId = userService.GetUserIdWithGivenEmailAndPassword(email,password);
            return userId;
        }
    }
}
