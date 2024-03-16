using AutoMapper;
using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace Fiap.Hackathon.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInputDto, IdentityUser>();
        CreateMap<IdentityUser, UserAuthorizedDto>();
    }
}