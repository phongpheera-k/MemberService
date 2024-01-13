namespace MemberService.Service.Services.Interfaces;

public interface ISignUpService
{
    Task<SignUpResponse?> SignUp(SignUpRequest request);
}