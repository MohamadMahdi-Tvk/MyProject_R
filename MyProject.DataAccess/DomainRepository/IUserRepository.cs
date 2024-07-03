using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.GenericRepository;
using MyProject.DataAccess.Models;

namespace MyProject.DataAccess.DomainRepository;

public interface IUserRepository : IRepository<User>
{
    
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DataBaseContext context, ILogger logger) : base(context, logger)
    {
    }

    
}