using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTaskApi.DAL.Interfaces;
using static TestTaskApi.DAL.Interfaces.ITestTaskRepository;

namespace TestTaskApi.DAL.Repositories
{
    public class SecuritiesInformationRepository<TEntity> : ITestTaskRepository<TEntity> where TEntity : class
    {

        private readonly ITestTaskUnitOfWork _unitOfWork;
        public SecuritiesInformationRepository(ITestTaskUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity item)
        {
            _unitOfWork.Context.Add(item);
            _unitOfWork.SaveChanges();
        }

        public void AddRange(ICollection<TEntity> itemList)
        {
            _unitOfWork.Context.AddRange(itemList);
            _unitOfWork.SaveChanges();
        }

        public void BulkInsert(ICollection<TEntity> itemList)
        {
            _unitOfWork.Context.BulkInsert(itemList.ToList());
            _unitOfWork.SaveChanges();
        }

        public TEntity SingleOrDefault(Func<TEntity, bool> predicate) => _unitOfWork.Context.Set<TEntity>().SingleOrDefault(predicate);

        public bool Any(Func<TEntity, bool> predicate) => _unitOfWork.Context.Set<TEntity>().Any(predicate);

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Where(predicate).ToList();
            if (entities.Any())
            {
                _unitOfWork.Context.Set<TEntity>().RemoveRange(entities);
                _unitOfWork.SaveChanges();
            }
        }

        public void Update(TEntity item)
        {
            _unitOfWork.Context.Set<TEntity>().Attach(item);
            _unitOfWork.Context.Entry(item).State = EntityState.Modified;
            _unitOfWork.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            if (_unitOfWork.Context.Entry(item).State == EntityState.Detached)
            {
                _unitOfWork.Context.Attach(item);
            }
            _unitOfWork.Context.Remove(item);
            _unitOfWork.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> item)
        {
            if (_unitOfWork.Context.Entry(item).State == EntityState.Detached)
            {
                _unitOfWork.Context.Attach(item);
            }
            _unitOfWork.Context.Remove(item);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _unitOfWork.Context.Set<TEntity>().Where(predicate).ToList();
            }
            return _unitOfWork.Context.Set<TEntity>().ToList();
        }

        public TEntity SingleOrDefaultWithInclude(Func<TEntity, bool> predicate, Expression<Func<TEntity, object>> includeProperties) => Include(includeProperties).SingleOrDefault(predicate);

        public IEnumerable<TEntity> WhereWithInclude(params Expression<Func<TEntity, object>>[] includeProperties) => Include(includeProperties).ToList();

        public IEnumerable<TEntity> WhereWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        #region Private
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>().AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        #endregion 
    }
}
