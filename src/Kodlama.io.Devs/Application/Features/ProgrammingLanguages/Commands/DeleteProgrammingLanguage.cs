//using Application.Features.ProgrammingLanguages.Dto;
//using Application.Features.ProgrammingLanguages.Rules;
//using Application.Services.Repositories;
//using AutoMapper;
//using Domain.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Features.ProgrammingLanguages.Commands
//{
//    public class DeleteProgrammingLanguage : IRequest<ProgrammingLanguageGetByIdDto>
//    {
//        public int Id { get; set; }

//        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguage, ProgrammingLanguageGetByIdDto>
//        {
//            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
//            private readonly IMapper _mapper;
//            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

//            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper
//                mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
//            {
//                _programmingLanguageRepository = programmingLanguageRepository;
//                _mapper = mapper;
//                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
//            }

//            public async Task<ProgrammingLanguageGetByIdDto> Handle(DeleteProgrammingLanguage request, CancellationToken cancellationToken)
//            {
               
//            }
//        }
//    }
//}