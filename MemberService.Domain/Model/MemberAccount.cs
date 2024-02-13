namespace MemberService.Domain.Model;

public class MemberAccount(Guid id, string? password, AccountLoginType accountLoginType) : BaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; } = id;
    public string? Password { get; set; } = password;
    public AccountLoginType AccountLoginType { get; set; } = accountLoginType;
}