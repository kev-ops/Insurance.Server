using AutoMapper;
using Insurance.Application;
using Insurance.Application.Interfaces;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Application.Interfaces.Services;
using Insurance.Domain.Classes;
using Insurance.Domain.Entities;
using Insurance.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHelper _helper;
        private readonly IMapper _mapper;
        public ConsumerService(
            IUnitOfWork unitOfWork,
            IHelper helper,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _helper = helper;
            _mapper = mapper;
        }
        public async Task<GetResult<Consumer>> GetAll(CancellationToken cancellationToken)
        {
            return await _unitOfWork.Consumer.GetAsync(cancellationToken);
        }
        public async Task<Consumer> FindAsync(int id)
        {
            return await _unitOfWork.Consumer.FindAsync(id);
        }
        public async Task<SaveResult> CalculateAndSaveBenefit(ConsumerDto entity, CancellationToken cancellationToken)
        {


            var setup = await _unitOfWork.InsuranceSetup.FindAsync(entity.InsuranceSetupId);

            if (setup == null)
            {
                return new SaveResult()
                {
                    message = "No record",
                    success = false
                };
            };


            var benefitDetailLists = await CalculateInsuranceBenefit(entity);

            var consumer = new Consumer()
            {
                InsuranceSetupId = entity.InsuranceSetupId,
                ConsumerName = entity.ConsumerName,
                BasicSalary = entity.BasicSalary,
                BirthDate = entity.BirthDate,
                Age = _helper.GetAge(entity.BirthDate),
                BenefitsDetails = benefitDetailLists
            };

            await _unitOfWork.Consumer.AddAsync(consumer);

            return await _unitOfWork.Complete(cancellationToken);

        }
        public async Task<GetResult<BenefitsDetail>> GetPreviewBenefitDetail(ConsumerDto entity)
        {

            var detail = await CalculateInsuranceBenefit(entity);


            var getResult = new GetResult<BenefitsDetail>()
            {
                data = detail,
                total = detail.Count(),
                success = true
            };

            return getResult;

        }

        public async Task<ConsumerBenefitsDto> GetConsumerWithDetails(int id)
        {

            var entity = await _unitOfWork.Consumer.GetQuery()
                            .Where(x => x.ConsumerId == id)
                            .Include(t => t.BenefitsDetails)
                            .FirstOrDefaultAsync();

            var result = _mapper.Map<ConsumerBenefitsDto>(entity);

            return result;

        }

        public async Task<IEnumerable<BenefitsDetail>> GetBenefitDetailsByConsumerId(int id)
        {
            return await _unitOfWork.BenefitDetail.FindAsync(t => t.ConsumerId == id);

        }

        public async Task<SaveResult> DeleteConsumer(int id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Consumer.FindAsync(id);

            _unitOfWork.Consumer.Delete(entity);

            return await _unitOfWork.Complete(cancellationToken);
        }
        public async Task<SaveResult> UpdateConsumer(Consumer entity, CancellationToken cancellationToken)
        {

            var recordInDatabase = await _unitOfWork.Consumer.GetQuery()
                                             .Where(s => s.ConsumerId == entity.ConsumerId)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();


            //if these fields are modified =>  Delete and insert record, recalculate
            if (recordInDatabase.InsuranceSetupId != entity.InsuranceSetupId
                || recordInDatabase.BasicSalary != entity.BasicSalary
                || recordInDatabase.BirthDate != entity.BirthDate)
            {


                var detailToDelete = await _unitOfWork.BenefitDetail.FindAsync(s => s.ConsumerId == entity.ConsumerId);

                _unitOfWork.BenefitDetail.RemoveRange(detailToDelete);

                var paramEntity = new ConsumerDto()
                {
                    InsuranceSetupId = entity.InsuranceSetupId,
                    BasicSalary = entity.BasicSalary,
                    BirthDate = entity.BirthDate,
                    ConsumerName = entity.ConsumerName
                };

                entity.BenefitsDetails = await CalculateInsuranceBenefit(paramEntity);

                _unitOfWork.Consumer.Update(entity);


            }
            else
                _unitOfWork.Consumer.Update(entity);


            return await _unitOfWork.Complete(cancellationToken);


        }




        #region private  methods
        private async Task<List<BenefitsDetail>> CalculateInsuranceBenefit(ConsumerDto entity)
        {
            var setup = await _unitOfWork.InsuranceSetup.FindAsync(entity.InsuranceSetupId);

            var benefitsDtoLists = new List<BenefitsDto>();

            if (setup != null)
            {



                int min_range = setup.MinRange;
                int max_range = setup.MaxRange;
                int increment = setup.Increments;

                //int age = Helper.GetAge(entity.BirthDate);
                int age = _helper.GetAge(entity.BirthDate);

                for (var idx = min_range; idx <= max_range; idx += increment)
                {
                    var benefitsDto = new BenefitsDto()
                    {
                        Multiple = idx,
                        Min_Age = setup.MinAge,
                        Max_Age = setup.MaxAge,
                        Age = age,
                        BasicSalary = entity.BasicSalary,
                        GuaranteedIssue = setup.GuaranteedIssue
                    };

                    benefitsDtoLists.Add(benefitsDto);


                }

            }
            var benefitsDetail = _mapper.Map<List<BenefitsDetail>>(benefitsDtoLists);

            return benefitsDetail;

        }


        #endregion
    }
}
