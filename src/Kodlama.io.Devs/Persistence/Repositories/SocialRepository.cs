using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SocialRepository : EfRepositoryBase<Social, BaseDbContext>, ISocialRepository
    {
        public SocialRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
