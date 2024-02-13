namespace MemberService.Service.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(JwtParameter parameter);
    Guid? GetId(string token);
}