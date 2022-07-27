using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> AddEntity(T entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            return addedEntity.Entity;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByName(string name)
        {
            return await _dbSet.FindAsync(name);
        }

        public IQueryable<T> List()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> RemoveEntity(int id)
        {
            var entity = await GetById(id);

            return _dbSet.Remove(entity).Entity;
        }

        public void Save()
        {
            _db.SaveChanges();   
        }
    }
}