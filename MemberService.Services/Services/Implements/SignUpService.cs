namespace MemberService.Services.Services.Implements;

public class SignUpService(IMemberAccountRepository memberAccountRepository,
    IHashService hashService,
    IJwtService jwtService) : ISignUpService
{
    public async Task<SignUpResponse?> SignUp(SignUpRequest request)
    {
        if (request.AccountLoginType.IsIn(AccountType.PasswordRequired) && request.Password.IsNullOrEmpty())
            throw new ArgumentException("Password is required");
        
        var passwordEncoder = request.AccountLoginType.IsIn(AccountType.PasswordRequired)
            ? hashService.PasswordHashing(request.Password.GetValueOrEmpty())
            : null;
        var memberAccount = new MemberAccount(request.Id, passwordEncoder, request.AccountLoginType);
        var member = await memberAccountRepository.CreateMember(memberAccount);
        var jwtParam = new JwtParameter(member.Id, new TimeSpan(30, 0, 0, 0));
        return new SignUpResponse { Token = jwtService.GenerateToken(jwtParam) };
    }
}