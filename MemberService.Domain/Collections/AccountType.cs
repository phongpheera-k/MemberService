using MemberService.Domain.Enums;

namespace MemberService.Domain.Collections;

public static class AccountType
{
    public static AccountLoginType[] PasswordRequired = [AccountLoginType.Code, AccountLoginType.Email];
}