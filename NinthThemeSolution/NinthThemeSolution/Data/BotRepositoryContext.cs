using Microsoft.EntityFrameworkCore;
using NinthThemeSolution.Models;
using System.Diagnostics.CodeAnalysis;

namespace NinthThemeSolution.Data
{
    public class BotRepositoryContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public BotRepositoryContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
