using TestTaskApi.DAL.EF;
using static TestTaskApi.DAL.Interfaces.ITestTaskRepository;

namespace TestTaskApi.DAL.Interfaces
{
    public interface ITestTaskUnitOfWork : IDisposable
    {
        TestTaskContext Context { get; }
        ITestTaskRepository<TEntity> GetRepository<TEntity>() where TEntity : class;  
        int SaveChanges();
    }
}
