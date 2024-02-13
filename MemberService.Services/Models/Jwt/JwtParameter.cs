namespace MemberService.Services.Models.Jwt;

public class JwtParameter(Guid id, TimeSpan expiredAge)
{
    public Guid Id { get; set; } = id;
    public DateTime ExpiredDate { get; set; } = DateTime.UtcNow.Add(expiredAge);
}