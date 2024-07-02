using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Models;
using System.Data;

namespace MyProject.DataAccess.Context;

public interface IDataBaseContext
{
    public DbSet<User> Users { get; set; }
    public IDbConnection Connection { get; }

}
