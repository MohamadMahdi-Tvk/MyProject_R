using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Models;
using System.Data;
using System.Reflection;

namespace MyProject.DataAccess.Context;

public class DataBaseContext : DbContext, IDataBaseContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public IDbConnection Connection => Database.GetDbConnection();
}
