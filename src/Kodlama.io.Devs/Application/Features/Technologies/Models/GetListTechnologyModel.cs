using Application.Features.Technologies.Dto;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Model
{
    public class GetListTechnologyModel : BasePageableModel
    {
        public IList<GetListTechnologyDto> Items { get; set; }
    }
}
