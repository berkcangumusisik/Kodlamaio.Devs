using Application.Features.Socials.Dto;
using Application.Features.Socials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Command.DeleteSocial
{
    public class DeleteSocialCommand : IRequest<UpdatedSocialDto>
    {
        public int Id { get; set; }

        public class DeleteSocialCommandQuery : IRequestHandler<DeleteSocialCommand, UpdatedSocialDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialRepository _socialRepository;
            private readonly SocialBusinessRules _socialBusinessRules;

            public DeleteSocialCommandQuery(IMapper mapper, ISocialRepository socialRepository, SocialBusinessRules socialBusinessRules)
            {
                _mapper = mapper;
                _socialRepository = socialRepository;
                _socialBusinessRules = socialBusinessRules; 
            }

            public async Task<UpdatedSocialDto> Handle(DeleteSocialCommand request,
                CancellationToken cancellationToken)
            {
                var entity = await _socialRepository.GetAsync(g => g.Id == request.Id);

                _socialBusinessRules.ProgrammingLanguageShouldExistWhen(entity);

                entity = await _socialRepository.DeleteAsync(entity);

                var deletedSocialDto = _mapper.Map<UpdatedSocialDto>(entity);

                return deletedSocialDto;
            }
        }

    }
}
