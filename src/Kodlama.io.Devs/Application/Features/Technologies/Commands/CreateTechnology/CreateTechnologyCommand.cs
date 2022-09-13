using Application.Features.Technologies.Dto;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreateTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreateTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }
            public async Task<CreateTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                var mappedTechnology = _mapper.Map<Domain.Entities.Technology>(request);
                var createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);

                IPaginate<Domain.Entities.Technology> technology = await _technologyRepository.GetListAsync(
                    c => c.Id == createdTechnology.Id,
                    include: p => p.Include(c => c.ProgrammingLanguage)
                );

                var createdTechnologyDto = _mapper.Map<CreateTechnologyDto>(technology.Items.FirstOrDefault());

                return createdTechnologyDto;
            }
        }
    }
}
