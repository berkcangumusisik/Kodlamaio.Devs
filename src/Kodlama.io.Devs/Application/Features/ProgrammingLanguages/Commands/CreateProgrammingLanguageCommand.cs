using Application.Features.ProgrammingLanguages.Dto;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands
{

    public class CreateProgrammingLanguageCommand : IRequest<CreateProgrammingLanguageDto>
    {
        public string Name
        {
            get; set;
        }
        public class CreateBrandCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public CreateBrandCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                ProgrammingLanguage mapppedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mapppedProgrammingLanguage);
                CreateProgrammingLanguageDto createProgrammingLanguageDto = _mapper.Map<CreateProgrammingLanguageDto>(createProgrammingLanguage);
                return createProgrammingLanguageDto;
            }
        }

        

    }
}
