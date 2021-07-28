using Insurance.Domain.Classes;
using Insurance.Domain.Entities;
using Insurance.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces.Services
{
    public interface IConsumerService
    {
        Task<GetResult<Consumer>> GetAll(CancellationToken cancellationToken);
        Task<GetResult<BenefitsDetail>> GetPreviewBenefitDetail(ConsumerDto entity);
        Task<ConsumerBenefitsDto> GetConsumerWithDetails(int id);
        Task<IEnumerable<BenefitsDetail>> GetBenefitDetailsByConsumerId(int id);
        Task<Consumer> FindAsync(int id);
        Task<SaveResult> DeleteConsumer(int id, CancellationToken cancellationToken);
        Task<SaveResult> CalculateAndSaveBenefit(ConsumerDto entity, CancellationToken cancellationToken);
        Task<SaveResult> UpdateConsumer(Consumer entity, CancellationToken cancellationToken);

    }
}
