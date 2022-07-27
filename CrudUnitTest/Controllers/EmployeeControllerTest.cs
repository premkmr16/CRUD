using CRUD.Controllers;
using CrudUnitTest.ModelBuilder;
using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Service.IService;
using Utilities.Response;

namespace CrudUnitTest.Controllers
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _employeeServiceMock;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTest()
        {
            _employeeServiceMock = new Mock<IEmployeeService>(MockBehavior.Strict);
            _employeeController = new EmployeeController(_employeeServiceMock.Object);
        }

        [Fact]
        public async void TestAddEmployee_Pass()
        {
            // Arrange
            var employeeBuilder = new EmployeeBuilder();

            employeeBuilder.WithId(100);
            employeeBuilder.WithName("Jhon");

            var employee = employeeBuilder.BuildEmployeeDTO();
            
           _employeeServiceMock.Setup(x => x.AddEmployee(It.IsAny<EmployeeDTO>()))
                .Returns(Task.FromResult(employee));

            // Act
            var response = await _employeeController.AddEmployee(employee) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status201Created, response?.StatusCode);
            Assert.Equal(Message.SuccessCode, value?.Code);
        }

        [Fact]
        public async void TestAddEmployee_Fail()
        {
            var employeeBuilder = new EmployeeBuilder();

            employeeBuilder.WithId(100);

            var employee = employeeBuilder.BuildEmployeeDTO();

            // Arrange
            _employeeServiceMock.Setup(x => x.AddEmployee(It.IsAny<EmployeeDTO>()))
                 .Returns(Task.FromResult<EmployeeDTO>(null));

            // Act
            var response = await _employeeController.AddEmployee(employee) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, response?.StatusCode);
            Assert.Equal(Message.InvalidDataCode, value?.Code);
        }

        [Fact]
        public async void TestAddEmployee_ExceptionFail()
        {
            // Arrange
            var employeeBuilder = new EmployeeBuilder();

            employeeBuilder.WithId(100);
            employeeBuilder.WithName("Jhon");

            var employee = employeeBuilder.BuildEmployeeDTO();

            _employeeServiceMock.Setup(x => x.AddEmployee(It.IsAny<EmployeeDTO>()))
                 .Throws<Exception>();

            // Act
            var response = await _employeeController.AddEmployee(employee) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status500InternalServerError, response?.StatusCode);
            Assert.Equal(Message.ApplicationErrorCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployeeById_Pass()
        {
            // Arrange
            var employeeBuilder = new EmployeeBuilder();

            employeeBuilder.WithId(100);
            employeeBuilder.WithName("John");

            var employee = employeeBuilder.BuildEmployeeDTO();

            _employeeServiceMock.Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                .Returns(Task.FromResult(employee));

            // Act
            var response = await _employeeController.GetEmployeeById(It.IsAny<int>()) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, response?.StatusCode);
            Assert.Equal(Message.SuccessCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployeeById_Fail()
        {
            // Arrange
            _employeeServiceMock.Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                .Returns(Task.FromResult<EmployeeDTO>(null));

            // Act
            var response = await _employeeController.GetEmployeeById(It.IsAny<int>()) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, response?.StatusCode);
            Assert.Equal(Message.FailureCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployeeById_ExceptionFail()
        {
            // Arrange
            _employeeServiceMock.Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                .Throws<Exception>();

            // Act
            var response = await _employeeController.GetEmployeeById(It.IsAny<int>()) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status500InternalServerError, response?.StatusCode);
            Assert.Equal(Message.ApplicationErrorCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployeeByName_Pass()
        {
            // Arrange
            var employeeBuilder = new EmployeeBuilder();

            employeeBuilder.WithId(100);
            employeeBuilder.WithName("John");

            var employee = employeeBuilder.BuildEmployeeDTO();

            _employeeServiceMock.Setup(x => x.GetEmployeeByName(It.IsAny<string>()))
                .Returns(Task.FromResult(employee));

            // Act
            var response = await _employeeController.GetEmployeeByName(It.IsAny<string>()) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, response?.StatusCode);
            Assert.Equal(Message.SuccessCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployeeByName_Fail()
        {
            // Arrange
            _employeeServiceMock.Setup(x => x.GetEmployeeByName(It.IsAny<string>()))
                .Returns(Task.FromResult<EmployeeDTO>(null));

            // Act
            var response = await _employeeController.GetEmployeeByName(It.IsAny<string>()) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, response?.StatusCode);
            Assert.Equal(Message.FailureCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployeeByName_ExceptionFail()
        {
            // Arrange
            _employeeServiceMock.Setup(x => x.GetEmployeeByName(It.IsAny<string>()))
                .Throws<Exception>();

            // Act
            var response = await _employeeController.GetEmployeeByName(It.IsAny<string>()) as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status500InternalServerError, response?.StatusCode);
            Assert.Equal(Message.ApplicationErrorCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployees_Pass()
        {
            // Arrange
            var employeeBuilder = new EmployeeBuilder();

            employeeBuilder.WithId(100);
            employeeBuilder.WithName("John");

            var employee = employeeBuilder.BuildEmployeeDTO();

            _employeeServiceMock.Setup(x => x.GetEmployees())
                .Returns(Task.FromResult(new List<EmployeeDTO> { employee }));

            // Act
            var response = await _employeeController.GetEmployees() as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, response?.StatusCode);
            Assert.Equal(Message.SuccessCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployees_Fail()
        {
            // Arrange
            _employeeServiceMock.Setup(x => x.GetEmployees())
                .Returns(Task.FromResult<List<EmployeeDTO>>(null));

            // Act
            var response = await _employeeController.GetEmployees() as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, response?.StatusCode);
            Assert.Equal(Message.FailureCode, value?.Code);
        }

        [Fact]
        public async void TestGetEmployees_ExceptionFail()
        {
            // Arrange
            _employeeServiceMock.Setup(x => x.GetEmployees())
                .Throws<Exception>();

            // Act
            var response = await _employeeController.GetEmployees() as ObjectResult;
            var value = response?.Value as ResponseMessage;

            // Assert
            Assert.Equal(StatusCodes.Status500InternalServerError, response?.StatusCode);
            Assert.Equal(Message.ApplicationErrorCode, value?.Code);
        }
    }
}
