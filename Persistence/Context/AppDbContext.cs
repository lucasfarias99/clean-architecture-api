using Microsoft.EntityFrameworkCore;
using CleanArchtecture.Domain.Entities;

namespace CleanArchitecture.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
    }
}
