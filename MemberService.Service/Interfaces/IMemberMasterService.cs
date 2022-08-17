using MemberService.Domain.Model;
using MemberService.Service.Domains;

namespace MemberService.Service.Interfaces;

public interface IMemberMasterService
{
    Task<IEnumerable<MemberMaster>> GetMember(GetMemberRequest request);
}