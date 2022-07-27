using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;
using Utilities.Response;

namespace CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employee)
        {
            try
            {
                if (employee.Name != null)
                {
                    return StatusCode(StatusCodes.Status201Created,
                        new ResponseMessage(Message.SuccessCode,
                            Message.GetMessages(Message.SuccessCode),
                               await _employeeService.AddEmployee(employee)));
                }

                return StatusCode(StatusCodes.Status400BadRequest,
                    new ResponseMessage(Message.InvalidDataCode,
                       Message.GetMessages(Message.InvalidDataCode)));
            }

            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseMessage(Message.ApplicationErrorCode,
                       Message.GetMessages(Message.ApplicationErrorCode),
                           exception.GetBaseException()));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);

                if (employee != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new ResponseMessage(Message.SuccessCode,
                            Message.GetMessages(Message.SuccessCode),
                                employee));
                }

                return StatusCode(StatusCodes.Status404NotFound,
                   new ResponseMessage(Message.FailureCode,
                      Message.GetMessages(Message.FailureCode)));
            }

            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseMessage(Message.ApplicationErrorCode,
                       Message.GetMessages(Message.ApplicationErrorCode),
                           exception.GetBaseException()));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByName(name);

                if (employee != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new ResponseMessage(Message.SuccessCode,
                            Message.GetMessages(Message.SuccessCode),
                                employee));
                }

                return StatusCode(StatusCodes.Status404NotFound,
                   new ResponseMessage(Message.FailureCode,
                      Message.GetMessages(Message.FailureCode)));
            }

            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseMessage(Message.ApplicationErrorCode,
                       Message.GetMessages(Message.ApplicationErrorCode),
                           exception.GetBaseException()));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();

                if (employees != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new ResponseMessage(Message.SuccessCode,
                            Message.GetMessages(Message.SuccessCode),
                                employees));
                }

                return StatusCode(StatusCodes.Status404NotFound,
                   new ResponseMessage(Message.FailureCode,
                      Message.GetMessages(Message.FailureCode)));
            }

            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseMessage(Message.ApplicationErrorCode,
                       Message.GetMessages(Message.ApplicationErrorCode),
                           exception.GetBaseException()));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.RemoveEmployee(id);

                if (employee != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new ResponseMessage(Message.SuccessCode,
                            Message.GetMessages(Message.SuccessCode),
                                employee));
                }

                return StatusCode(StatusCodes.Status404NotFound,
                      new ResponseMessage(Message.FailureCode,
                         Message.GetMessages(Message.FailureCode)));
            }           

            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new ResponseMessage(Message.ApplicationErrorCode,
                      Message.GetMessages(Message.ApplicationErrorCode),
                          exception.GetBaseException()));
            }
        }
    }
}