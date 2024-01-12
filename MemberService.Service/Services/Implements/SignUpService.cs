using System.Security.Claims;
using System.Text;
using JoeGerienLib.Extension;
using MemberService.Domain.Collections;
using MemberService.Domain.Model;
using MemberService.Repository.Repositories.Interfaces;
using MemberService.Service.Helpers;
using MemberService.Service.Models.SignUp;
using MemberService.Service.Services.Interfaces;

namespace MemberService.Service.Services.Implements;

public class SignUpService(IMemberRepository memberRepository) : ISignUpService
{
    public async Task<SignUpResponse?> SignUp(SignUpRequest request)
    {
        var passwordEncoder = request.AccountLoginType.IsIn(AccountType.PasswordRequired)
            ? EncodeHelper.GenerateSHA256String(request.Password)
            : null;
        var memberAccount = new MemberAccount(request.Id, passwordEncoder, request.AccountLoginType);
        var member = await memberRepository.CreateMember(memberAccount);
        
        // // JWT generation
        // var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        // var key = Encoding.ASCII.GetBytes("Your_Security_Key"); // Replace with your secret key
        // var tokenDescriptor = new SecurityTokenDescriptor
        // {
        //     Subject = new ClaimsIdentity(new Claim[] 
        //     {
        //         new Claim(ClaimTypes.Name, member.Id.ToString())
        //     }),
        //     Expires = DateTime.UtcNow.AddDays(1), // set token expiration as per your requirements
        //     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        // };
        // var token = tokenHandler.CreateToken(tokenDescriptor);
        // var tokenString = tokenHandler.WriteToken(token);
        //
        // return new SignUpResponse { Token = tokenString };
        throw new NotImplementedException();
    }
}