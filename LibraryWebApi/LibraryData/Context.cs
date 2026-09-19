using LibraryWebApi.LibraryData.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryData
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
