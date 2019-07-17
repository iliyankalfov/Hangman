using Hangman.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hangman.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<WordCategory> WordCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WordDifficultyTable> WordDifficultyTables { get; set; }
        public DbSet<UserGuessed> UsersGuessed { get; set; }
    }
}
