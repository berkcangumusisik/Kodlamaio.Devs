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
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper
                mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }


            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                programmingLanguage.IsActive = false;

                var deleteProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                var mapEntity = _mapper.Map<DeleteProgrammingLanguageDto>(deleteProgrammingLanguage);
                return mapEntity;
            }
        }
    }
}