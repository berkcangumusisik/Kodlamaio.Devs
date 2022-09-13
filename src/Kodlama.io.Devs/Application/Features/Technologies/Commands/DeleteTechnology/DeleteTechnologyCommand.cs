using Application.Features.Technologies.Dto;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeleteTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeleteTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<DeleteTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                var mappedTechnology = _mapper.Map<Domain.Entities.Technology>(request);

                IPaginate<Domain.Entities.Technology> technologyToDelete = await _technologyRepository.GetListAsync(
                    e => e.Id == mappedTechnology.Id,
                    include: p => p.Include(c => c.ProgrammingLanguage)
                );

                await _technologyRepository.DeleteAsync(technologyToDelete.Items.FirstOrDefault());

                var deletedTechnologyDto = _mapper.Map<DeleteTechnologyDto>(technologyToDelete.Items.FirstOrDefault());

                return deletedTechnologyDto;
            }
        }
    }
}
