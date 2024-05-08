using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Authors> authors { get; set; }
        public DbSet<Books> books { get; set; }
        public DbSet<Members> members { get; set; }
        public DbSet<BorrowedBooks> borrowedBooks { get; set; }
    }
}