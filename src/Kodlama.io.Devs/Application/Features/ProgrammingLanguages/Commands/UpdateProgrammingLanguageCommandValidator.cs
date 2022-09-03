using Application.Features.ProgrammingLanguages.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageDto>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);

        }
    }
}
