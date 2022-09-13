using Application.Features.Developers.Commands.CreateDeveloper;
using Application.Features.Developers.Dto;
using AutoMapper;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Developer, RegisterUserCommand>().ReverseMap();
            CreateMap<TokenDto, AccessToken>().ReverseMap();
        }
    }
}

