using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().MinimumLength(2);
            RuleFor(t => t.ProgrammingLanguageId).NotEmpty();
        }
    }
}
