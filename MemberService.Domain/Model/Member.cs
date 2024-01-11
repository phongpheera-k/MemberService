namespace MemberService.Domain.Model;

public class Member(string id) : BaseModel
{
    public string Id { get; set; } = id;
    public string Password { get; set; } = string.Empty;
}