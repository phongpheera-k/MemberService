namespace MemberService.Repository.Repositories.Interfaces;

public interface IMemberAccountRepository
{
    Task<MemberAccount?> GetMember(Guid id);
    Task<MemberAccount> CreateMember(MemberAccount memberAccount);
}