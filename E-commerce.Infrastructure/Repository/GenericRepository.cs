using E_commerce.Domain.Contracts;
using E_commerce.Domain.Entities;
using E_commerce.Infrastructure.dbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_commerce.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly E_commerceContext _context;

        public GenericRepository(E_commerceContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}

        //public async Task<T?> GetByIdAsync(int id)
        //{
        //    return await _context.Set<T>().FindAsync(id);
        //}

        //public async Task AddAsync(T entity)
        //{
        //    await _context.Set<T>().AddAsync(entity);
        //}

        //public void Update(T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //}

        //public void Delete(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //}

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // Default version without includes
            return await _context.Set<T>().ToListAsync();
        }

        // New method to include navigation properties
        //public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> query = _context.Set<T>();
        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }
        //    return await query.ToListAsync();
        //}

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

    }
}
