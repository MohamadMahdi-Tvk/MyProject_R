using Microsoft.Extensions.Logging;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.GenericRepository;
using MyProject.DataAccess.Models;

namespace MyProject.DataAccess.DomainRepository;

public interface IRoleRepository : IRepository<Role>
{
}

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(DataBaseContext context, ILogger logger) : base(context, logger)
    {
    }
}
