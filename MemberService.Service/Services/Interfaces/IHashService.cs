namespace MemberService.Service.Services.Interfaces;

public interface IHashService
{
    string PasswordHashing(string password);
    bool VerifyPassword(string password, string passwordEncode);
}