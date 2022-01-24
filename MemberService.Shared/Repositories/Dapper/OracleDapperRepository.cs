using System.Runtime.ExceptionServices;
using DataAbstractions.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace MemberService.Shared.Repositories.Dapper;

public class OracleDapperRepository : IOracleDapperRepository
{
    private readonly ILogger<OracleDapperRepository> _logger;
    private readonly string _connectionString;

    public OracleDapperRepository(ILogger<OracleDapperRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("OracleDapperConnectionString");
    }

    public IDataAccessor OpenDbConnection() => new DataAccessor(new OracleConnection(_connectionString));

    public async Task<IEnumerable<T>> QueryData<T>(string sqlCommand, object sqlParams)
    {
        async Task<IEnumerable<T>> ExecuteConnection(string sqlCommandParam, object sqlParamsParam)
        {
            using var connection = OpenDbConnection();
            return await connection.QueryAsync<T>(sqlCommand, sqlParams);
        }

        return await ProcessRetryQuery(ExecuteConnection, sqlCommand, sqlParams);
    }

    public async Task<int> ExecuteQuery(string sqlCommand, object sqlParams)
    {
        async Task<int> ExecuteConnection(string sqlCommandParam, object sqlParamsParam)
        {
            using var connection = OpenDbConnection();
            return await connection.ExecuteAsync(sqlCommand, sqlParams);
        }

        return await ProcessRetryQuery(ExecuteConnection, sqlCommand, sqlParams);
    }
    
    private async Task<T> ProcessRetryQuery<T>(Func<string, object, Task<T>> executeConnection, string sqlCommand, object sqlParams)
    {
        var result = default(T);
        var nRetryOnException = 3;
        var isSuccess = false;
        while (nRetryOnException > 0 && !isSuccess)
        {
            try
            {
                result = await executeConnection(sqlCommand, sqlParams);
                isSuccess = true;
            }
            catch (OracleException ex)
            {
                _logger.LogError($"nRetryOnException: {nRetryOnException}\nException: {ex.Message}\nsqlParams: {sqlParams}");
                if (nRetryOnException <= 1)
                    ExceptionDispatchInfo.Capture(ex).Throw();
            }
            nRetryOnException--;
        }
        return result ?? Activator.CreateInstance<T>();
    }
}