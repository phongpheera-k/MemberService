namespace MemberService.Service.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(JwtParameter parameter);
    bool VerifyToken(string token);
}