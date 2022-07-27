using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddEntity(T entity);
        IQueryable<T> List();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<T> RemoveEntity(int id);
        void Save();
    }
}
