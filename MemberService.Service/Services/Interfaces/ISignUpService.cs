using MemberService.Domain.Model;
using MemberService.Service.Models.SignUp;

namespace MemberService.Service.Services.Interfaces;

public interface ISignUpService
{
    Task<SignUpResponse?> SignUp(SignUpRequest request);
}