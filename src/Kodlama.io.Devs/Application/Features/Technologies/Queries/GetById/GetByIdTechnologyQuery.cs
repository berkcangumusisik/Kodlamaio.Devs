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

namespace Application.Features.Technology.Queires.GetById
{
    public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GetByIdTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                var mappedTechnology = _mapper.Map<Domain.Entities.Technology>(request);
                IPaginate<Domain.Entities.Technology> technology = await _technologyRepository.GetListAsync(
                    p => p.Id == request.Id & p.IsActive == true,
                    include: p => p.Include(c => c.ProgrammingLanguage)
                );

                GetByIdTechnologyDto getByIdTechnologyDto = _mapper.Map<GetByIdTechnologyDto>(technology.Items.FirstOrDefault());

                return getByIdTechnologyDto;
            }
        }

    }
}
