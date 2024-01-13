namespace MemberService.Service.Services.Implements;

public class JwtService : IJwtService
{
    private readonly SymmetricSecurityKey _key;
    private readonly SigningCredentials _creds;

    public JwtService(IConfiguration configuration)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        _creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
    }

    public string GenerateToken(JwtParameter parameter)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, parameter.Id)
            }),
            Expires = parameter.ExpiredDate,
            SigningCredentials =  _creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public bool VerifyToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _key,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out _);

            return true;
        }
        catch
        {
            return false;
        }
    }
}