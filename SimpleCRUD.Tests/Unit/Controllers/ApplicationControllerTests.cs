using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SimpleCRUD.API.Controllers;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.Data.Entities;
using Xunit;

namespace SimpleCRUD.Tests.Unit.Controllers
{

    public class ApplicationControllerTests
    {
        private readonly Mock<ILogger<ApplicationController>> _loggerMock;
        private readonly Mock<IApplicationService> _applicationServiceMock;
        private readonly ApplicationController _controller;

        public ApplicationControllerTests()
        {
            _loggerMock = new Mock<ILogger<ApplicationController>>();
            _applicationServiceMock = new Mock<IApplicationService>();
            _controller = new ApplicationController(_loggerMock.Object, _applicationServiceMock.Object);
        }

        [Fact]
        public async Task GetAllApplications_WhenApplicationsExist_ReturnsOkResult()
        {
            //arrange the fake application in memory
            var applications = new List<Applications>
            {
                new Applications
                {
                    ApplicationId = Guid.NewGuid(),
                    ApplicationName = "SimpleCRUD",
                    ApplicationDescription = "Test application"
                }
            };

            //setup the fake application for when the service is called
            _applicationServiceMock
                .Setup(x => x.GetAllApplications())
                .ReturnsAsync(applications);

            //call the controller method
            var result = await _controller.GetAllApplications();

            //did the controller return ok?
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;

            //was the value of the ok result a list of applications?
            var value = okResult.Value.Should()
                .BeAssignableTo<List<Applications>>()
                .Subject;

            //checking list of contents
            value.Should().HaveCount(1);
            value.First().ApplicationName.Should().Be("SimpleCRUD");

            //verify that the service method was called once
            _applicationServiceMock.Verify(x => x.GetAllApplications(), Times.Once);
        }
    }
}
