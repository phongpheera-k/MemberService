namespace MemberService.Services.Models.SignUp;

public class SignUpRequest
{
    [Required] public Guid Id { get; set; }
    public string? Password { get; set; }
    public AccountLoginType AccountLoginType { get; set; }
}