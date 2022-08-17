using MemberService.Domain.Model;

namespace MemberService.Repository.Interfaces;

public interface IMemberMasterRepository
{
    Task<MemberMaster?> GetMemberById(string memberId);
    Task<IEnumerable<MemberMaster>> GetMemberByName(string name);
    Task<IEnumerable<MemberMaster>> GetMemberBySurname(string surname);
}