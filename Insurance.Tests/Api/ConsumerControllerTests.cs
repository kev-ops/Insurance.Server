using Insurance.Application.Interfaces.Services;
using Insurance.Domain.Classes;
using Insurance.Domain.Entities;
using Insurance.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Insurance.Tests.Api
{
    public class ConsumerControllerTests
    {
        private readonly ConsumerController _controller;
        private readonly Mock<IConsumerService> _consumerServiceMock = new Mock<IConsumerService>();
        private readonly Mock<ILogger<ConsumerController>> _mockLogger = new Mock<ILogger<ConsumerController>>();

        public ConsumerControllerTests()
        {
            _controller = new ConsumerController(_consumerServiceMock.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturn_ValidGetResult()
        {
            //Arrange
            CancellationToken cancellationToken = default;

            _consumerServiceMock.Setup(x => x.GetAll(cancellationToken))
                    .ReturnsAsync(new GetResult<Consumer>());

            //Act
            var response = await _controller.GetAll();
     

            //Assert
            _consumerServiceMock.Verify(x => x.GetAll(cancellationToken), Times.Once);
            Assert.IsType<OkObjectResult>((ObjectResult)response); //Ensure Http 200
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)((ObjectResult)response).StatusCode);

        }
    }
}
