using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fiap.Hackathon.Application.Common;
using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.Hackathon.Application.Services.Common;

public class AuthenticationService(IConfiguration config, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, NotificationContext notificationContext)
    : IAuthenticationService
{
    private string? GenerateToken(IdentityUser user, IList<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        if (user.Email == null) return null;
        
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName!),
            new Claim(ClaimTypes.Role, string.Join(",", roles)),
            new Claim(ClaimTypes.Email,  user.Email)
        };
        var token = new JwtSecurityToken(config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<UserAuthorizedDto?> GenerateAuthorizedToken(string userName, string password)
    {
        var login = await signInManager
            .PasswordSignInAsync(userName, password, false, false);

        if (login.Succeeded)
        {
            var user = await userManager.Users
                .FirstOrDefaultAsync(u => u.UserName.Equals(userName));

            if (user is not null)
            {
                var roles = await userManager.GetRolesAsync(user);

                var token = GenerateToken(user, roles);


                return new UserAuthorizedDto
                {
                    Authorized = true,
                    Email = user.Email,
                    ExpiresIn = (int)(DateTime.Now.AddMinutes(15) - DateTime.Now).TotalSeconds,
                    Token = token,
                    UserName = user.UserName
                };
            }
        }

        notificationContext.AddNotification("NotAuthorized", "Login ou senha incorretos!");
        return null;
    }
}