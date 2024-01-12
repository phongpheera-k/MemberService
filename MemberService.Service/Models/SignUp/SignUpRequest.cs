using MemberService.Domain.Enums;

namespace MemberService.Service.Models.SignUp;

public class SignUpRequest
{
    public string Id { get; set; }
    public string Password { get; set; }
    public AccountLoginType AccountLoginType { get; set; }
}