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
        public void CreateUser(string email, string password)
        {
            bool isLoggedIn = false;
            var user = new User()
            {
                Email = email,
                Password = password
            };
            CheckIfLoggedIn(isLoggedIn, user);
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

        public void CheckIfLoggedIn(bool flag, User user)
        {
            foreach (var userLog in context.Users)
            {
                if (userLog.Email == user.Email && userLog.Password == user.Password)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
