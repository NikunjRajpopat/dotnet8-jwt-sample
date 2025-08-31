using Microsoft.EntityFrameworkCore;
using Dotnet8JwtSample.Domain.Entities;

namespace Dotnet8JwtSample.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}