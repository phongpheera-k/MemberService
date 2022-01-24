using DataAbstractions.Dapper;

namespace MemberService.Shared.Repositories.Dapper;

public interface IOracleDapperRepository
{
    IDataAccessor OpenDbConnection();
    Task<IEnumerable<T>> QueryData<T>(string sqlCommand, object sqlParams);
    Task<int> ExecuteQuery(string sqlCommand, object sqlParams);
}