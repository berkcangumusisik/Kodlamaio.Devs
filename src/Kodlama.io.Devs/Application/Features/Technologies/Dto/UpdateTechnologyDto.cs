using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dto
{
    public class UpdateTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public bool IsActive { get; set; }
    }
}
