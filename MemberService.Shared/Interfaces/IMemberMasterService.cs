using MemberService.Model;
using MemberService.Repository.Domains;

namespace MemberService.Shared.Interfaces;

public interface IMemberMasterService
{
    Task<IEnumerable<MemberMaster>> GetMember(GetMemberRequest request);
}