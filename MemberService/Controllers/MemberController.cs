using MemberService.Service.Domains;
using MemberService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MemberService.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : Controller
{
    private readonly IMemberMasterService _memberMasterService;

    public MemberController(IMemberMasterService memberMasterService)
    {
        _memberMasterService = memberMasterService;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> GetMember(GetMemberRequest request)
    {
        var result = await _memberMasterService.GetMember(request);

        return result.Any() ? Ok(result) : BadRequest();
    }
}