namespace MemberService.Services.Services.Implements;

public class HashService(IConfiguration configuration) : IHashService
{
    private readonly string _key = configuration["Secret:Key"]!;
    private readonly string _salt = configuration["Secret:Salt"]!;
    public string PasswordHashing(string password)
    {
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_salt + _key));
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = hmac.ComputeHash(bytes);
        return GetStringFromHash(hash);
    }
    
    private string GetStringFromHash(byte[] hash)
    {
        StringBuilder result = new StringBuilder();
        foreach (var t in hash)
        {
            result.Append(t.ToString("X2"));
        }
        return result.ToString();
    }

    public bool VerifyPassword(string password, string passwordEncode)
        => passwordEncode == PasswordHashing(password);
}