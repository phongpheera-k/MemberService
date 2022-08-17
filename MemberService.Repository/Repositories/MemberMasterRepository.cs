using MemberService.Domain.Model;
using MemberService.Repository.Dapper;
using MemberService.Repository.Interfaces;

namespace MemberService.Repository.Repositories;

public class MemberMasterRepository : IMemberMasterRepository
{
    private readonly IDatabaseDapperRepository _databaseDapper;

    public MemberMasterRepository(IDatabaseDapperRepository databaseDapper)
    {
        _databaseDapper = databaseDapper;
    }


    public async Task<MemberMaster?> GetMemberById(string memberId)
    {
        const string sqlCommand = @"select member_id as MemberId, name, sur_name as SurName, birth_date as BirthDate
                 from MemberMaster
                 where member_id = :memberId";
        return (await _databaseDapper.QueryData<MemberMaster>(sqlCommand, new {memberId = memberId})).SingleOrDefault();
    }

    public async Task<IEnumerable<MemberMaster>> GetMemberByName(string name)
    {
        const string sqlCommand = @"select member_id as MemberId, name, sur_name as SurName, birth_date as BirthDate
                 from MemberMaster
                 where name = :name";
        return await _databaseDapper.QueryData<MemberMaster>(sqlCommand, new {name = name});
    }

    public async Task<IEnumerable<MemberMaster>> GetMemberBySurname(string surname)
    {
        const string sqlCommand = @"select member_id as MemberId, name, sur_name as SurName, birth_date as BirthDate
                 from MemberMaster
                 where surname = :surname";
        return await _databaseDapper.QueryData<MemberMaster>(sqlCommand, new {surname = surname});
    }
    
    // public async Task 
}