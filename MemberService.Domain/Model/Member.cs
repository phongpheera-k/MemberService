namespace MemberService.Domain.Model;

public class Member
{
    public Member(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
    public string Name { get; init; }
    public string Surname { get; init; }
    public DateTime BirthDay { get; set; }
    public List<Address> Address { get; set; }

    public int Age => DateTime.Now.Year - BirthDay.Year;

    public int GetAge(DateTime today)
    {
        return today.Year - BirthDay.Year;
    }

    public string GetThisFullAddress(int index) => Address[index].AllAddress();

    public void AddAddress(Address address) => Address.Add(address);
    public void AddsAddress(IEnumerable<Address> addresses) => Address.AddRange(addresses);
}



public class Address
{
    public string AddType { get; set; }
    public string MooBan { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public string PostCode { get; set; }

    // public string FullAddress => AllAddress();

    public string AllAddress() => MooBan + District + Province + PostCode;
}

