using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyProject.DataAccess.Context;
using System.Data;
using static Dapper.SqlMapper;

namespace MyProject.DataAccess.Connections;

public class ApplicationReadDbConnection : IApplicationReadDbConnection, IDisposable
{
    private readonly IDbConnection connection;

    public ApplicationReadDbConnection(IConfiguration configuration)
    {
        connection = new SqlConnection(configuration.GetConnectionString("Default"));
    }
    public async Task<List<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
    {
        return (await connection.QueryAsync<T>(sql, param, transaction, commandType: commandType)).AsList();
    }

    public async Task<T> QueryFirstAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
    {
        return await connection.QueryFirstAsync<T>(sql, param, transaction, commandType: commandType);
    }

    public async Task<GridReader> QueryMultipleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
    {
        return (await connection.QueryMultipleAsync(sql, param, transaction, commandType: commandType));
    }

    public async Task<T> QueryScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
    {
        return await connection.ExecuteScalarAsync<T>(sql, param, transaction, commandType: commandType);
    }

    public void Dispose()
    {
        connection.Dispose();
    }
}
public class ApplicationWriteDbConnection : IApplicationWriteDbConnection
{
    private readonly DataBaseContext context;
    public ApplicationWriteDbConnection(DataBaseContext context)
    {
        this.context = context;
    }
    public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await context.Connection.ExecuteAsync(sql, param, transaction);
    }
}