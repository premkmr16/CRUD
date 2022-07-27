using DTO.Models;

namespace CrudUnitTest.ModelBuilder
{
    public class EmployeeBuilder
    {
        private int _id;
        private string _name;

        public EmployeeBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public EmployeeBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public EmployeeDTO BuildEmployeeDTO()
        {
            return new EmployeeDTO
            {
                Id = _id,
                Name = _name,
            };
        }
    }
}
    