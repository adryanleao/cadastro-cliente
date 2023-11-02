using System.Linq.Expressions;

namespace Cliente.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    void Add(TEntity obj);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    void Update(TEntity obj);
    void Remove(TEntity obj);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    IUnitOfWork UnitOfWork { get; }
}
