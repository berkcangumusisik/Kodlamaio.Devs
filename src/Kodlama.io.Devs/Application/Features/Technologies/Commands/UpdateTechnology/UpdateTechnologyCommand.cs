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


namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdateTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdateTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdateTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                var mappedEntity = _mapper.Map<Domain.Entities.Technology>(request);

                var updateEntity = await _technologyRepository.UpdateAsync(mappedEntity);

                IPaginate<Domain.Entities.Technology> technology = await _technologyRepository.GetListAsync(
                c => c.Id == request.Id,
                include: p => p.Include(c => c.ProgrammingLanguage)
              );


                var updatedTechnologyDto = _mapper.Map<UpdateTechnologyDto>(technology.Items.FirstOrDefault());

                return updatedTechnologyDto;


            }
        }

    }
}
