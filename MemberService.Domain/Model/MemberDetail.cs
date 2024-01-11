namespace MemberService.Domain.Model;

public class MemberDetail(string id) : BaseModel
{
    public string Id { get; set; } = id;
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public List<MemberAddress>? Addresses { get; set; }
    public List<MemberContact>? Contacts { get; set; }
    public DateTime? BirthDay { get; set; }

    public int? Age => BirthDay.HasValue ? DateTime.Now.Year - BirthDay.Value.Year : null;
}

