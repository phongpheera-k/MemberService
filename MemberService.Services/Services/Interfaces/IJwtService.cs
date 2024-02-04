namespace MemberService.Service.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(JwtParameter parameter);
    string? GetId(string token);
}