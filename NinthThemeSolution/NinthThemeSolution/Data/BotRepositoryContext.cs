using Microsoft.EntityFrameworkCore;
using NinthThemeSolution.Models;
using System.Diagnostics.CodeAnalysis;

namespace NinthThemeSolution.Data
{
    public class BotRepositoryContext : DbContext
    {
        public DbSet<Aphorism> Aphorisms { get; set; }
        public DbSet<Anecdote> Anecdotes { get; set; }
        public DbSet<HelloPhrase> HelloPhrases { get; set; }
        public DbSet<ByePhrase> ByePhrases { get; set; }

        public DbSet<AnecdoteRequest> AnecdotesRequests { get; set; }
        public DbSet<HelloPhraseRequest> HelloPhrasesRequests { get; set; }
        public DbSet<ByePhraseRequest> ByePhrasesRequests { get; set; }

        public BotRepositoryContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
