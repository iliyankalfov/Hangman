using Hangman.Data;
using Hangman.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public int UserId { get; set; } = 0;
        public void CreateUser(string email, string password)
        {
            var user = new User()
            {
                Email = email,
                Password = password
            };
            if(!context.Users.Contains<User>(user))
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public int GetUserIdWithGivenEmailAndPassword(string email,string password)
        {
            var userId = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            return userId.Id;
        }

        public void DeleteAllUsers()
        {
            var users = context.Users;
            context.Users.RemoveRange(users);
            context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            var users = context.Users;
            return users.ToList();
        }
    }
}
