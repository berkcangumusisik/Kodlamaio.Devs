using Application.Features.Technology.Model;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Queires.GetList
{
    public class GetListTechnologyQuery : IRequest<GetListTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, GetListTechnologyModel>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;

        public GetListTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
        }

        public async Task<GetListTechnologyModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Technology> technologies = await _technologyRepository.GetListAsync
                   (a => a.IsActive == true, include: t => t.Include(c => c.ProgrammingLanguage),
                  index: request.PageRequest.Page,
                  size: request.PageRequest.PageSize);

            var mappedTechnologyModel = _mapper.Map<GetListTechnologyModel>(technologies);
            return mappedTechnologyModel;

        }
    }

}
