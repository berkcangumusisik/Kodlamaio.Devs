using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Command.CreateSocial
{
    public class CreateSocialCommandValidator : AbstractValidator<CreateSocialCommand>
    {
        public CreateSocialCommandValidator()
        {
            RuleFor(s => s.DeveloperId).NotEmpty();
            RuleFor(s => s.GithubProfile).NotEmpty();
        }
    }
}
