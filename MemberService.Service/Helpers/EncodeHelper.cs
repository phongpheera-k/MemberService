using System.Security.Cryptography;
using System.Text;

namespace MemberService.Service.Helpers;

public static class EncodeHelper
{
    // ReSharper disable once InconsistentNaming
    public static string GenerateSHA256String(string inputString) 
    {
        SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(inputString);
        byte[] hash = sha256.ComputeHash(bytes);
        return GetStringFromHash(hash);
    }

    private static string GetStringFromHash(byte[] hash)
    {
        StringBuilder result = new StringBuilder();
        foreach (var t in hash)
        {
            result.Append(t.ToString("X2"));
        }
        return result.ToString();
    }
}