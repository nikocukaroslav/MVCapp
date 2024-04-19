using MVCapp.Models.Domain;
namespace MVCapp.Data;
using Microsoft.EntityFrameworkCore;

public class MVCappDbContext : DbContext 
{
    public MVCappDbContext(DbContextOptions<MVCappDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }

}