namespace MemberService.Service.Domains;

public class GetMemberRequest
{
    public string? MemberId { get; set; }
    public string? Name { get; set; }
    public string? SurName { get; set; }
}