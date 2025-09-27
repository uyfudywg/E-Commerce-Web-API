using E_commerce.Domain.Contracts;
using E_commerce.Domain.Entities;
using E_commerce.Infrastructure.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repository
{
   public class UnitOfWork : IUnitOfWork
    {

        private readonly E_commerceContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(E_commerceContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new GenericRepository<T>(_context);
                _repositories[type] = repositoryInstance;
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

