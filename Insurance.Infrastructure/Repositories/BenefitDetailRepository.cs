using Insurance.Application.Interfaces.Persistence;
using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Repositories
{
    public class BenefitDetailRepository : Repository<BenefitsDetail>, IBenefitDetailRepository
    {
        public BenefitDetailRepository(DbContext context) : base(context)
        {

        }
    }
}
