

using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class,new ()
    {
        protected readonly RepositoryContext _repositoryContext;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
        }

        public void deleteProduct(T entity)
        {
           _repositoryContext.Set<T>().Remove(entity);
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ?
                _repositoryContext.Set<T>().Where(expression).SingleOrDefault()
                : _repositoryContext.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            return trackChanges ?
                _repositoryContext.Set<T>() :
                _repositoryContext.Set<T>().AsNoTracking();
        }

       
    }
}
