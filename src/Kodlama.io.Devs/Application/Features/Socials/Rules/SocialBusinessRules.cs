using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Rules
{
    public class SocialBusinessRules
    {
        private readonly ISocialRepository _socialRepository;

        public SocialBusinessRules(ISocialRepository socialRepository)
        {
            _socialRepository = socialRepository;
        }

        public async Task GitHubProfileCanNotBeDuplicatedWhenInserted(int developerId)
        {
            var developer = await _socialRepository.GetAsync(s => s.DeveloperId == developerId);
            if (developer != null) throw new BusinessException("Zaten atanmış bir GitHub profili var");

        }

        public void ProgrammingLanguageShouldExistWhen(Social social)
        {
            if (social.GithubProfile == null) throw new BusinessException("İstenen GitHub profili mevcut değil");
        }

    }
}
