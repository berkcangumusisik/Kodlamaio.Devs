using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Command.UpdateSocial
{
    public class UpdateSocialCommandValidator : AbstractValidator<UpdateSocialCommand>
    {
        public UpdateSocialCommandValidator()
        {
            RuleFor(s => s.GithubProfile).NotEmpty();
            RuleFor(s => s.Id).NotEmpty();
        }
    }
}
