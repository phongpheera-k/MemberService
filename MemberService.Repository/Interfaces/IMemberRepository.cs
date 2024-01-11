namespace MemberService.Repository.Interfaces;

public interface IMemberRepository
{
    Task<Member?> GetMember(string id);
    Task<Member> CreateMember(Member member);
}