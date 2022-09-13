using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Queires.GetById
{
    public class GetByIdTechnologyQueryValidator : AbstractValidator<GetByIdTechnologyQuery>
    {
        public GetByIdTechnologyQueryValidator()
        {
            RuleFor( t => t.Id ).NotEmpty();
        }
    }
}
