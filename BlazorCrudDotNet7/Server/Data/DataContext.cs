using BlazorCrudDotNet7.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }


    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

}

