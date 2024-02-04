namespace MemberService.Domain.Model;

public class MemberDetail(string id) : BaseModel
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = id;
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public DateTime? BirthDay { get; set; }
    public List<MemberAddress>? Addresses { get; set; }

    public int? Age => BirthDay.HasValue ? DateTime.Now.Year - BirthDay.Value.Year : null;
}

