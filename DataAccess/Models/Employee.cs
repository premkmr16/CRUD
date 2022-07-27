using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }          
        public string Name { get; set; }
    }
}
