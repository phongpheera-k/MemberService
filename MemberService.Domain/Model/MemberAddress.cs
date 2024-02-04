namespace MemberService.Domain.Model;

public class MemberAddress
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Telephone { get; set; }
    public string Address { get; set; } = string.Empty;
    public string? AddressMore { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string PostalCode { get; set; } = string.Empty;
}