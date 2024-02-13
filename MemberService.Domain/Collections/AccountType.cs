namespace MemberService.Domain.Collections;

public static class AccountType
{
    public static readonly AccountLoginType[] PasswordRequired = [AccountLoginType.Code, AccountLoginType.Email];
}