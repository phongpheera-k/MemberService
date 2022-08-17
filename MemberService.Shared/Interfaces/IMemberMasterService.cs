using MemberService.Domain.Model;
using MemberService.Model;

namespace MemberService.Shared.Interfaces;

public interface IMemberMasterService
{
    Task<IEnumerable<MemberMaster>> GetMember(GetMemberRequest request);
}