using Application.Features.Socials.Dto;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Model
{
    public class GithubProfileListModel : BasePageableModel
    {
        public IList<SocialListDto> Items { get; set; }
    }
}
