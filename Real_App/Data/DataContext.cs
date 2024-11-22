using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Real_App.Model;

namespace Real_App.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    
    
}