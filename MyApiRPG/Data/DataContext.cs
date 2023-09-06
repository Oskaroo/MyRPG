using Microsoft.EntityFrameworkCore;

namespace MyApiRPG.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Character> Characters => Set<Character>();
}