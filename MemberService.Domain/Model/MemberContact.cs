namespace MemberService.Domain.Model;

public class MemberContact
{
    public string MemberId { get; set; } = string.Empty;
    public string? Telephone { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
}