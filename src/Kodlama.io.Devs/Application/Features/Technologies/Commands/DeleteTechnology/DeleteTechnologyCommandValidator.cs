using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidator : AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty();

        }
    }
}
