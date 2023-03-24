using System.Linq.Expressions;

namespace TestTaskApi.DAL.Interfaces
{
    public interface ITestTaskRepository
    {
        public interface IRepositoryBase<TEntity>
        {
            IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null);
            TEntity SingleOrDefault(Func<TEntity, bool> predicate);
            void Add(TEntity item);
            void Delete(Expression<Func<TEntity, bool>> predicate);
            void Delete(TEntity item);
            void DeleteRange(IEnumerable<TEntity> item);
            void Update(TEntity item);
        }

        public interface ITestTaskRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
        {
            bool Any(Func<TEntity, bool> predicate);
            void BulkInsert(ICollection<TEntity> itemList);
            void AddRange(ICollection<TEntity> itemList);
            IEnumerable<TEntity> WhereWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);  
            IEnumerable<TEntity> WhereWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);  
            TEntity SingleOrDefaultWithInclude(Func<TEntity, bool> predicate, Expression<Func<TEntity, object>> includeProperties);
        }
    }
}
