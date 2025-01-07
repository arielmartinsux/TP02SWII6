using Microsoft.EntityFrameworkCore;
using TP02SWII6.Model;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

    public DbSet<BL> BLs { get; set; }
    public DbSet<Container> Containers { get; set; }
}

