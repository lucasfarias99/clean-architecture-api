﻿using AutoMapper;
using CleanArchtecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.UpdateUser;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UpdateUserResponse>();
    }
}