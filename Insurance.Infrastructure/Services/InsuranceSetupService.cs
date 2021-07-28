using Insurance.Application.Interfaces.Persistence;
using Insurance.Application.Interfaces.Services;
using Insurance.Domain.Classes;
using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Services
{
    public class InsuranceSetupService : IInsuranceSetupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InsuranceSetupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<GetResult<InsuranceSetup>> GetAll(CancellationToken cancellationToken)
        {
            return await _unitOfWork.InsuranceSetup.GetAsync(cancellationToken);

        }

        public async Task<SaveResult> SaveSetup(InsuranceSetup entity, CancellationToken cancellationToken)
        {
            await _unitOfWork.InsuranceSetup.AddAsync(entity);

            var result = await _unitOfWork.Complete(cancellationToken);

            return result;
        }

        public async Task<SaveResult> UpdateSetup(InsuranceSetup entity, CancellationToken cancellationToken)
        {
            _unitOfWork.InsuranceSetup.Update(entity);

            return await _unitOfWork.Complete(cancellationToken);
        }
        public async Task<SaveResult> DeleteSetup(int id, CancellationToken cancellationToken)
        {
            _unitOfWork.InsuranceSetup.Delete(id);

            return await _unitOfWork.Complete(cancellationToken);
        }
    }
}
