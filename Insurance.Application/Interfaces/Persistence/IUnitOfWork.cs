using Insurance.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IInsuranceSetupRepository InsuranceSetup { get; }
        IConsumerRepository Consumer { get; }
        IBenefitDetailRepository BenefitDetail { get; }
        Task<SaveResult> Complete(CancellationToken cancellationToken);
    }
}
