using DTO.Models;

namespace Service.Service.IService
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> AddEmployee(EmployeeDTO employee);
        Task<List<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<EmployeeDTO> GetEmployeeByName(string name);
        Task<EmployeeDTO> RemoveEmployee(int id);
    }
}
