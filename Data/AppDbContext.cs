using DkGourmet.Entites;
using Microsoft.EntityFrameworkCore;

namespace DkGourmet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> opt) : DbContext(opt)
{
    public DbSet<Produto> Produto { get; set; }
}