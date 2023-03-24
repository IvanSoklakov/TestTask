using TestTaskApi.DAL.EF;
using TestTaskApi.DAL.Interfaces;
using static TestTaskApi.DAL.Interfaces.ITestTaskRepository;

namespace TestTaskApi.DAL.Repositories
{
    /// <summary>
    /// Паттерн Unit of Work позволяет упростить работу с различными репозиториями и дает уверенность, что все репозитории будут использовать один и тот же контекст данных.
    /// </summary>  
    public class TestTaskUnitOfWork : ITestTaskUnitOfWork
    {
        public TestTaskContext Context { get; }
     
        private bool _disposed;
        private Dictionary<Type, object> _repositories;

        public TestTaskUnitOfWork(TestTaskContext context)
        {
            Context = context;
            _disposed = false;
        }

        public ITestTaskRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
                _repositories[type] = new SecuritiesInformationRepository<TEntity>(this);
            return (ITestTaskRepository<TEntity>)_repositories[type];
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
