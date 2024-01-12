namespace MemberService.Service.Models.SignUp;

public class SignUpResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiredDate { get; set; }
}