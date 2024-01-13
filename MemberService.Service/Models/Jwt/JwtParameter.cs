namespace MemberService.Service.Models.Jwt;

public class JwtParameter(string id, TimeSpan expiredAge)
{
    public string Id { get; set; } = id;
    public DateTime ExpiredDate { get; set; } = DateTime.UtcNow.Add(expiredAge);
}