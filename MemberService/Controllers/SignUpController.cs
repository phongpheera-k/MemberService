using MemberService.Service.Models.SignUp;

namespace MemberService.Controllers;

[ApiController]
[Route("[controller]")]
public class SignUpController(ISignUpService signUpService) : Controller
{
    [HttpPost]
    public async Task<ActionResult<SignUpResponse>> SignUp([FromBody] SignUpRequest request)
    {
        var result = await signUpService.SignUp(request);
        return result is not null ? Ok(result) : BadRequest();
    }
}