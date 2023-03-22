

using _01_EntityFramWorkProjekt.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFramWorkProjekt.Contexts;

internal class DataContext : DbContext
{
    #region constructors and overrides
    public DataContext()
    { }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\elie-\OneDrive\Desktop\ConsoleApp\EntityFramWorkApp\01-EntityFramWorkProjekt\Contexts\EntityDb2.mdf;Integrated Security=True;Connect Timeout=30");
    }

    #endregion

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
}

