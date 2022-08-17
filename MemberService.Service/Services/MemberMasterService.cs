using MemberService.Domain.Model;
using MemberService.Repository.Interfaces;
using MemberService.Service.Domains;
using MemberService.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace MemberService.Service.Services;

public class MemberMasterService : IMemberMasterService
{
    private readonly IMemberMasterRepository _memberMaster;
    private readonly ILogger<MemberMaster> _logger;

    public MemberMasterService(IMemberMasterRepository memberMaster, ILogger<MemberMaster> logger)
    {
        _memberMaster = memberMaster;
        _logger = logger;
    }
    public async Task<IEnumerable<MemberMaster>> GetMember(GetMemberRequest request)
    {
        _logger.LogInformation($"parameter is {request}");

        var memberById = new List<MemberMaster>();
        var memberByName = new List<MemberMaster>();
        var memberBySurname = new List<MemberMaster>();

        if (request.MemberId is not null)
            memberById.Add((await _memberMaster.GetMemberById(request.MemberId))!);

        if (request.Name is not null)
            memberByName = (await _memberMaster.GetMemberByName(request.Name)).ToList();
        
        if (request.SurName is not null)
            memberBySurname = (await _memberMaster.GetMemberByName(request.SurName)).ToList();

        var member = memberById.Union(memberByName)
            .Union(memberBySurname);
        
        return member;
    }

}