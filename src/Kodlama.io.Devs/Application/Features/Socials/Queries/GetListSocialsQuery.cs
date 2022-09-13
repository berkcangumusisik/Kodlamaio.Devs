using Application.Features.Socials.Model;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Queries
{
    public class GetListSocialsQuery : IRequest<GithubProfileListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } = new string[1] { "admin" };

        public class GetListSocialsQueryHandler : IRequestHandler<GetListSocialsQuery, GithubProfileListModel>
        {
            private readonly IMapper _mapper;
            private readonly ISocialRepository _socialRepository;

            public GetListSocialsQueryHandler(IMapper mapper, ISocialRepository socialRepository)
            {
                _mapper = mapper;
                _socialRepository = socialRepository;
            }

            public async Task<GithubProfileListModel> Handle(GetListSocialsQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Social> profiles = await _socialRepository
                    .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                GithubProfileListModel githubProfileListModel = _mapper.Map<GithubProfileListModel>(profiles);

                return githubProfileListModel;
            }
        }
    }
}
