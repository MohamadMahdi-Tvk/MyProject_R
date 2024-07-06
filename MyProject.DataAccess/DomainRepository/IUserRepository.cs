using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.GenericRepository;
using MyProject.DataAccess.Models;

namespace MyProject.DataAccess.DomainRepository;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserWithRoles(int Id);
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DataBaseContext context, ILogger logger) : base(context, logger)
    {
    }

    public async Task<User> GetUserWithRoles(int Id)
    {
        var user = await _context.Users.Include(p => p.Role)
             .SingleOrDefaultAsync(p => p.Id == Id);

        return user;
    }
}