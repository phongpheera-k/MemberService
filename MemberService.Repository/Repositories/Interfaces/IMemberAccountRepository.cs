namespace MemberService.Repository.Repositories.Interfaces;

public interface IMemberAccountRepository
{
    Task<MemberAccount?> GetMember(string id);
    Task<MemberAccount> CreateMember(MemberAccount memberAccount);
}