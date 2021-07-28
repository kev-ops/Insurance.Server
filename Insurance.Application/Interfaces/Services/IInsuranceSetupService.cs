using Insurance.Domain.Classes;
using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces.Services
{
    public interface IInsuranceSetupService
    {
        Task<GetResult<InsuranceSetup>> GetAll(CancellationToken cancellationToken);
        Task<SaveResult> SaveSetup(InsuranceSetup entity, CancellationToken cancellationToken);
        Task<SaveResult> UpdateSetup(InsuranceSetup entity, CancellationToken cancellationToken);
        Task<SaveResult> DeleteSetup(int id, CancellationToken cancellationToken);
    }
}
