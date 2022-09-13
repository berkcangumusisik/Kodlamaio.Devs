using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dto;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Model;
using Application.Features.Technology.Queires.GetById;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Domain.Entities.Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Domain.Entities.Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<Domain.Entities.Technology, CreateTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Domain.Entities.Technology, DeleteTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<Domain.Entities.Technology, UpdateTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();

            CreateMap<Domain.Entities.Technology, GetByIdTechnologyQuery>().ReverseMap();
            CreateMap<Domain.Entities.Technology, GetByIdTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();

            CreateMap<Domain.Entities.Technology, GetListTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Technology>, GetListTechnologyModel>().ReverseMap();


        }
    }
}
