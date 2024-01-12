namespace MemberService.Repository.Repositories.Interfaces;

public interface IMemberRepository
{
    Task<MemberAccount?> GetMember(string id);
    Task<MemberAccount> CreateMember(MemberAccount memberAccount);
}