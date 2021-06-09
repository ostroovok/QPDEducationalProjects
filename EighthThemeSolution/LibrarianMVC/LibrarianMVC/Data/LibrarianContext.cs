using LibrarianMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarianMVC.Data
{
    public class LibrarianContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }

        public LibrarianContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}
