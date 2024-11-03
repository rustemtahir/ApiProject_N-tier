
using APIDers1.Core.Entities.Base;
using System.Linq.Expressions;

namespace APIDers1.Core.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task AddAsync(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> expression);
        public IQueryable<T> GetAll();
        public int Save();
        public Task<int> SaveAsyc();
    }
}
