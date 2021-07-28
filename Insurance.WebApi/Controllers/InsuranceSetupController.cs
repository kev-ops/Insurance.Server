using Insurance.Application.Interfaces.Persistence;
using Insurance.Application.Interfaces.Services;
using Insurance.Domain.Classes;
using Insurance.Domain.Entities;
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
    [Route("api/insurancesetup")]
    [ApiController]
    public class InsuranceSetupController : ControllerBase
    {
     
        private readonly IInsuranceSetupService _insuranceSetupService;
        private readonly ILogger _logger;
        public InsuranceSetupController(
            IInsuranceSetupService insuranceSetupService,
            ILogger<InsuranceSetupController> logger
            )
        {
            _insuranceSetupService = insuranceSetupService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var result = await _insuranceSetupService.GetAll(cancellationToken);

            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] InsuranceSetup entity, CancellationToken cancellationToken = default)
        {
            var result = await _insuranceSetupService.SaveSetup(entity, cancellationToken);

            if (result.success)
                return Ok(result);
            else
            {
                _logger.LogInformation("InsuranceSetupController.Post transaction failed", result.message);

                return BadRequest(result);
            }

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] InsuranceSetup entity, CancellationToken cancellationToken = default)
        {
            SaveResult result = default;

            if (ModelState.IsValid)
            {

                result =  await _insuranceSetupService.UpdateSetup(entity, cancellationToken);

                if (result.success)
                    return Ok(result);
                else
                {
                    _logger.LogInformation("InsuranceSetupController.Put failed transaction", result.message);

                    return BadRequest(result);
                }

            }
            else
                return BadRequest("Model State is not valid.");

        }
  
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] int id, CancellationToken cancellationToken = default)
        {


            var result = await _insuranceSetupService.DeleteSetup(id, cancellationToken);

            if (result.success)
                return Ok(result);
            else
            {
                _logger.LogInformation("InsuranceSetupController.DeleteById failed transaction", result.message);
                return BadRequest(result);
            }
        }

    }
}
