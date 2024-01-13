using JoeGerienLib.Extension;
using MemberService.Domain.Collections;
using MemberService.Domain.Model;
using MemberService.Repository.Repositories.Interfaces;

namespace MemberService.Service.Services.Implements;

public class SignUpService(IMemberAccountRepository memberAccountRepository,
    IHashService hashService,
    IJwtService jwtService) : ISignUpService
{
    public async Task<SignUpResponse?> SignUp(SignUpRequest request)
    {
        var passwordEncoder = request.AccountLoginType.IsIn(AccountType.PasswordRequired)
            ? hashService.PasswordHashing(request.Password)
            : null;
        var memberAccount = new MemberAccount(request.Id, passwordEncoder, request.AccountLoginType);
        var member = await memberAccountRepository.CreateMember(memberAccount);
        var jwtParam = new JwtParameter(member.Id, new TimeSpan(30, 0, 0, 0));
        return new SignUpResponse { Token = jwtService.GenerateToken(jwtParam) };
    }
}