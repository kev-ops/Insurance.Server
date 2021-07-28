using Insurance.Application.Interfaces.Persistence;
using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces.Service
{
    public class InsuranceSetupService : BaseService<InsuranceSetup>, IInsuranceSetupService
    {
        public InsuranceSetupService(IRepository<InsuranceSetup> db) : base(db)
        {

        }
     
    }
}
