using System;
using Xunit;
using Moq;

using AutoMapper;
using Insurance.Infrastructure.Services;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Domain.ViewModel;
using Insurance.Application;
using System.Threading.Tasks;
using Insurance.Domain.Entities;
using System.Collections.Generic;
using Insurance.Application.Common.Mappings;
using Insurance.Application.Interfaces;
using Insurance.Domain.Classes;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Insurance.Domain.Common;

namespace Insurance.Tests
{
    public class ConsumerServiceTests
    {
        private readonly ConsumerService _service;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IHelper> _helper = new Mock<IHelper>();
        private static IMapper _mapper;
        public ConsumerServiceTests()
        {

            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapConfig.CreateMapper();
            _mapper = mapper;

            _service = new ConsumerService(_unitOfWorkMock.Object, _helper.Object, _mapper);
        }

        [Fact]
        public async Task GetPreviewBenefitDetail_ShouldReturnBenefits_WithinAgeLimit_And_PendedAmount()
        {
            //Arrange

            var consumerDto = new ConsumerDto()
            {
                InsuranceSetupId = 1,
                ConsumerName = "Consumer A",
                BasicSalary = 50_000,
                BirthDate = DateTime.Parse("06/22/1980")
            };

            var insuranceSetup = new InsuranceSetup()
            {
                InsuranceSetupId = 1,
                MinAge = 1,
                MaxAge = 67,
                MinRange = 1,
                MaxRange = 5,
                Increments = 1,
                GuaranteedIssue = 50_000
            };

            var expectedResult = new List<BenefitsDetail>()
            {
                new BenefitsDetail()
                {
                    Multiple = 1,
                    Benefits_Amount_Quotation = 50_000,
                    Pended_Amount = 0,
                    Benefits = 50_000
                },
                new BenefitsDetail()
                {
                    Multiple = 2,
                    Benefits_Amount_Quotation = 10_0000,
                    Pended_Amount = 50_000,
                    Benefits = null
                },
                new BenefitsDetail()
                {
                    Multiple = 3,
                    Benefits_Amount_Quotation = 150_000,
                    Pended_Amount = 100_000,
                    Benefits = null
                },
                new BenefitsDetail()
                {
                    Multiple = 4,
                    Benefits_Amount_Quotation = 200_000,
                    Pended_Amount = 150_000,
                    Benefits = null

                },
                new BenefitsDetail()
                {
                    Multiple = 5,
                    Benefits_Amount_Quotation = 250_000,
                    Pended_Amount = 200_000,
                    Benefits = null
                }
            };


            _unitOfWorkMock.Setup(x => x.InsuranceSetup.FindAsync(It.IsAny<int>()))
                            .ReturnsAsync(insuranceSetup);

            _helper.Setup(x => x.GetAge(It.IsAny<DateTime>()))
                        .Returns(41);

            //Act
            var result = await _service.GetPreviewBenefitDetail(consumerDto);
            var actualResult = result.data;

            //Assert


            Assert.Equal(expectedResult.Count, actualResult.Count);
            Assert.Equal(expectedResult, actualResult, new TestComparer());
        }

        [Fact]
        public async Task GetPreviewBenefitDetail_ShouldReturnBenefits_WithinAgeLimit_And_NoPendedAmount()
        {
            //Arrange

            var consumerDto = new ConsumerDto()
            {
                InsuranceSetupId = 1,
                ConsumerName = "Consumer A",
                BasicSalary = 50_000,
                BirthDate = DateTime.Parse("06/22/1980")
            };

            var insuranceSetup = new InsuranceSetup()
            {
                InsuranceSetupId = 1,
                MinAge = 1,
                MaxAge = 67,
                MinRange = 1,
                MaxRange = 5,
                Increments = 1,
                GuaranteedIssue = 50_000
            };


      
            var expectedResult = new List<BenefitsDetail>()
            {
                new BenefitsDetail()
                {
                    Multiple = 1,
                    Benefits_Amount_Quotation = 50_000,
                    Pended_Amount = 0,
                    Benefits = 50_000
                },
                new BenefitsDetail()
                {
                    Multiple = 2,
                    Benefits_Amount_Quotation = 10_0000,
                    Pended_Amount = 0,
                    Benefits = 10_0000
                },
                new BenefitsDetail()
                {
                    Multiple = 3,
                    Benefits_Amount_Quotation = 150_000,
                    Pended_Amount = 0,
                    Benefits = 150_000
                },
                new BenefitsDetail()
                {
                    Multiple = 4,
                    Benefits_Amount_Quotation = 200_000,
                    Pended_Amount = 0,
                    Benefits = 200_000

                },
                new BenefitsDetail()
                {
                    Multiple = 5,
                    Benefits_Amount_Quotation = 250_000,
                    Pended_Amount = 0,
                    Benefits = 250_000
                }
            };


            _unitOfWorkMock.Setup(x => x.InsuranceSetup.FindAsync(It.IsAny<int>()))
                            .ReturnsAsync(insuranceSetup);

            _helper.Setup(x => x.GetAge(It.IsAny<DateTime>()))
                        .Returns(68);

            //Act
            var result = await _service.GetPreviewBenefitDetail(consumerDto);
            var actualResult = result.data;

            //Assert
            Assert.Equal(expectedResult.Count, actualResult.Count);
            Assert.Equal(expectedResult, actualResult, new TestComparer());
        }
    }


}
