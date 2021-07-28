using AutoMapper;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Application.Interfaces.Services;
using Insurance.Domain.Entities;
using Insurance.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Route("api/consumer")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerService _consumerService;
        private readonly ILogger _logger;
        public ConsumerController(
            IConsumerService consumerService,
            ILogger<ConsumerController> logger
            )
        {
            _consumerService = consumerService;
            _logger = logger;
    
        }

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _consumerService.GetAll(cancellationToken);

            return Ok(result);
        }
        [HttpGet]
        [Route("getconsumerwithdetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetConsumerWithDetails(int id)
        {
            var result = await _consumerService.GetConsumerWithDetails(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("getbenefitdetailsbyconsumerid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBenefitDetailsByConsumerId(int id)
        {
            return Ok(await _consumerService.GetBenefitDetailsByConsumerId(id));
        }
        [HttpGet]
        [Route("getpreviewbenefit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPreviewBenefit([FromQuery] ConsumerDto entity)
        
        {
            var result = await _consumerService.GetPreviewBenefitDetail(entity);

            return Ok(result);
        }
     
      
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Find([FromQuery] int id)
        {
            return Ok(await _consumerService.FindAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ConsumerDto entity, CancellationToken cancellationToken = default)
        {
            var result = await _consumerService.CalculateAndSaveBenefit(entity, cancellationToken);

            //var data = await _unitOfWork.Consumer.CalculateBenefit(entity);

            //var benefitsDetail = _mapper.Map<List<BenefitsDetail>>(data);

            //var consumer = new Consumer()
            //{
            //    InsuranceSetupId = entity.InsuranceSetupId,
            //    ConsumerName = entity.ConsumerName,
            //    BasicSalary = entity.BasicSalary,
            //    BirthDate = entity.BirthDate,
            //    BenefitsDetails = benefitsDetail
            //};

            //await _unitOfWork.Consumer.AddAsync(consumer);

            //var result = await _unitOfWork.Complete(cancellationToken);

            if (result.success)
                return Ok(result);
            else
            {
                _logger.LogInformation("ConsumerController.Post transaction failed", result.message);

                return BadRequest(result);
            }

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] Consumer entity, CancellationToken cancellationToken = default)
        {
            var result = await _consumerService.UpdateConsumer(entity, cancellationToken);

            if (result.success)
                return Ok(result);
            else
            {
                _logger.LogInformation("ConsumerController.Delete transaction failed", result.message);

                return BadRequest(result);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await _consumerService.DeleteConsumer(id, cancellationToken);

            if (result.success)
                return Ok(result);
            else
            {
                _logger.LogInformation("ConsumerController.Delete transaction failed", result.message);

                return BadRequest(result);
            }
        }


    }
}
