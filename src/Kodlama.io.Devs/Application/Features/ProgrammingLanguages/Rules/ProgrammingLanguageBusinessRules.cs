
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Girdiğiniz Programlama Dili Sistemde Yer Alıyor.");
        }

        public async Task ProgrammingLanguageShouldBeExist(int id)
        {
            var result = await _programmingLanguageRepository.GetAsync(w => w.Id == id);
            if (result is null) throw new BusinessException($"Girdiğiniz Id ile programlama dili yoktur {id}");
        }

    }

}

