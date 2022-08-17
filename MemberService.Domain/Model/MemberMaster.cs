namespace MemberService.Domain.Model;

public class MemberMaster
{
    public string MemberId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}