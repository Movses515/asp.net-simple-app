using Demo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Core.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
