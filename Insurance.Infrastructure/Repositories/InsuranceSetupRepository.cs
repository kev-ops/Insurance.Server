using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories
{
    public class InsuranceSetupRepository : Repository<InsuranceSetup>, IInsuranceSetupRepository
    {
        public InsuranceSetupRepository(DbContext context) : base(context)
        {
            
        }
    
    }
}
