using AutoMapper;
using Fiap.Hackathon.Application.Common;
using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.User;
using Fiap.Hackathon.Application.Services.Common;
using Fiap.Hackathon.Application.Validators;
using Microsoft.AspNetCore.Identity;

namespace Fiap.Hackathon.Application.Services.User;

public class UserService(UserManager<IdentityUser> userManager, NotificationContext notificationContext,
        IMapper mapper, IAuthenticationService authenticationService)
    : IUserService
{
    public async Task<UserAuthorizedDto?> CreateAsync(UserInputDto user)
    {
        user.Validate(new UserInputDtoValidator());

        if (user.Invalid)
        {
            notificationContext.AddNotifications(user.ValidationResult);
            return null;
        }

        var userDomain = mapper.Map<IdentityUser>(user);

        var result = await userManager.CreateAsync(userDomain);
        await userManager.AddPasswordAsync(userDomain, user.Password);

        if (result.Succeeded)
            return await authenticationService.GenerateAuthorizedToken(userDomain.UserName!, user.Password);

        return null;
    }

    public async Task<UserAuthorizedDto?> LoginAsync(UserLoginDto login)
        => await authenticationService.GenerateAuthorizedToken(login.UserName, login.Password);
}