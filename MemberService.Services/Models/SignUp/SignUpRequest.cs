namespace MemberService.Services.Models.SignUp;

public class SignUpRequest
{
    [Required] public string Id { get; set; } = string.Empty;
    public string? Password { get; set; }
    public AccountLoginType AccountLoginType { get; set; }
}