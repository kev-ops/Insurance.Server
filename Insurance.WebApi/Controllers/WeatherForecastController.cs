using Insurance.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            const int min_range = 1;
            const int max_range = 5;
            const int salary = 80_000;
            DateTime BirthDate = DateTime.Now;
            decimal Guaranteed_Issue = 50_000;
            //  decimal Benefits_Amount_Quotation = (salary * increments);
            // decimal Pended_Amount = (Benefits_Amount_Quotation - Guaranteed_Issue);

            var list = new List<Output>();
            for (var i = min_range; i <= max_range; i++)
            {
                var multiple = i;
                var Benefits_Amt_Quotation = (salary * multiple);
                var aged = 22;



                var entity = new Output()
                {
                    Multiple = multiple,
                    BenefitsAmountQuotation = Benefits_Amt_Quotation,
                    PendedAmount = (Benefits_Amt_Quotation - Guaranteed_Issue),
                    Benefits = "For approval"
                };

                list.Add(entity);
            }

            var min_age = 25;
            var max_age = 55;
            BirthDate = DateTime.Parse("06/01/1980");
            var basicSalary = 80_000;
            var guaranteed_issue = 50_000;
            var increments = 3;

            var age = 1; //Helper.GetAge(BirthDate);

            var list2 = new List<BenefitsDto>();

            for (var idx = min_range; idx <= max_range; idx += increments)
            {
               

                var entity = new BenefitsDto()
                {
                    Multiple = idx,
                    Min_Age = min_age,
                    Max_Age = max_age,
                    Age = age,
                    BasicSalary = basicSalary,
                    GuaranteedIssue = guaranteed_issue
                };

                list2.Add(entity);
            }

            //    var rowCount = Math.Round(max_range / increments);

            var listDto = Enumerable.Range(1, 2).Select(idx => new BenefitsDto
            {
                Increment = idx,
                Min_Age = min_age,
                Max_Age = max_age,
                Age = age,
                BasicSalary = basicSalary,
                GuaranteedIssue = guaranteed_issue

            }).Select(x => new { x.Increment, x.BenefitsAmountQuotation, x.PendedAmount, x.Benefits });

            var rng = new Random();


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Index = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }
    public class BenefitsDto
    {
        private decimal _pendedAmout = 0;

        public int Increment { get; set; }
        public int Min_Age { get; set; }
        public int Max_Age { get; set; }
        public int Age { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal GuaranteedIssue { get; set; }
        public int Multiple { get; set; }
        public bool IsWithinRange => (Age >= Min_Age || Age <= Max_Age);
        public decimal Computed => (BenefitsAmountQuotation - GuaranteedIssue);
        public decimal BenefitsAmountQuotation => (BasicSalary * Multiple);

        public decimal PendedAmount
        {
            get
            {
                //if within age range
                if (Age >= Min_Age || Age <= Max_Age)
                {
                    _pendedAmout = BenefitsAmountQuotation > Computed ? Computed : 0;

                }

                return _pendedAmout;
            }
        }
        public decimal? Benefits => !IsWithinRange ? BenefitsAmountQuotation : null;
        public string Remarks => PendedAmount == 0 ? "Approved" : "For Approval";
    }
    public class Output
    {
        public int Multiple { get; set; }
        public decimal BenefitsAmountQuotation { get; set; }
        public decimal PendedAmount { get; set; }
        public string Benefits { get; set; }

    }
}

