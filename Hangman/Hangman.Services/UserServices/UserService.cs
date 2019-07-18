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
            bool ifExist = false;
            if(context.Users.Any(x => x.Email == email && x.Password != password))
            {
                ifExist = true;
            }
            bool isLoggedIn = false;
            var user = new User()
            {
                Email = email,
                Password = password
            };
            if(!ifExist)
            {
                CheckIfLoggedIn(isLoggedIn, user);
            }
            else
            {
                throw new ArgumentException("Enter another email!");
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
            return users.OrderByDescending(x => x.Points).ToList();
        }

        public void UpdateUserPointsWithGivenUserIdAndPoints(int userId, int points)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            user.Points += points;
            context.SaveChanges();
        }

        public User GetUser(int userId)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            return user;
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
