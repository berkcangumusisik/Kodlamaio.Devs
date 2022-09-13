using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {

        }

        public Technology(int id, int programmingLanguageId, string name, bool isActive) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            IsActive = isActive;


        }
    }
}