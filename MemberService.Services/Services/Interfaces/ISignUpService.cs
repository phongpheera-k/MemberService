namespace MemberService.Services.Services.Interfaces;

public interface ISignUpService
{
    Task<SignUpResponse?> SignUp(SignUpRequest request);
}