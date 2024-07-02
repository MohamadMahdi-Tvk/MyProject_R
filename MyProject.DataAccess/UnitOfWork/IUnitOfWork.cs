using MyProject.DataAccess.Connections;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.DomainRepository;

namespace MyProject.DataAccess.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    IRoleRepository RoleRepository { get; }

    IApplicationReadDbConnection ApplicationReadDbConnection { get; }
    IApplicationWriteDbConnection ApplicationWriteDbConnection { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken);
}

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IApplicationReadDbConnection _applicationReadDbConnection;
    private readonly IApplicationWriteDbConnection _applicationWriteDbConnection;
    private readonly IRoleRepository _roleRepository;
    public UnitOfWork(DataBaseContext context, IUserRepository userRepository,
        IApplicationReadDbConnection applicationReadDbConnection, IApplicationWriteDbConnection applicationWriteDbConnection
        , IRoleRepository roleRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _applicationReadDbConnection = applicationReadDbConnection;
        _applicationWriteDbConnection = applicationWriteDbConnection;
        _roleRepository = roleRepository;
    }
    public IUserRepository UserRepository => _userRepository;

    public IApplicationReadDbConnection ApplicationReadDbConnection => _applicationReadDbConnection;

    public IApplicationWriteDbConnection ApplicationWriteDbConnection => _applicationWriteDbConnection;

    public IRoleRepository RoleRepository => _roleRepository;

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}