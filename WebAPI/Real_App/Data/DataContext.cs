﻿using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Real_App.Model;

namespace Real_App.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyType> PropertyTypes { get; set; }
    public DbSet<FurnishingType> FurnishingTypes { get; set; }


}