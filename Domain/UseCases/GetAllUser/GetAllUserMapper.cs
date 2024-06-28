using AutoMapper;
using CleanArchtecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GetAllUser;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}