using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Models;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Service.Service.IService;

namespace Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO employee)
        {
            var addedEntity = _mapper.Map<Employee>(employee);
            addedEntity  = await _employeeRepository.AddEntity(addedEntity);
            _employeeRepository.Save();
            return _mapper.Map<EmployeeDTO>(addedEntity);
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            return _mapper.Map<EmployeeDTO>(await _employeeRepository.GetById(id));
        }

        public async Task<EmployeeDTO> GetEmployeeByName(string name)
        {
            return _mapper.Map<EmployeeDTO>(await _employeeRepository.GetByName(name));
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return _mapper.Map<List<EmployeeDTO>>(await _employeeRepository.List().ToListAsync());
        }

        public async Task<EmployeeDTO> RemoveEmployee(int id)
        {            
            return _mapper.Map<EmployeeDTO>(await _employeeRepository.RemoveEntity(id));
        }
    }
}
