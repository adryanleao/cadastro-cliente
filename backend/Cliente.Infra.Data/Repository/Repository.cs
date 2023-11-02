using System.Linq.Expressions;
using Cliente.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Infra.Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly ClienteContext Db;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(ClienteContext db)
    {
        Db = db;
        DbSet = Db.Set<TEntity>();
    }

    public IUnitOfWork UnitOfWork => Db;

    public void Add(TEntity obj)
    {
        DbSet.Add(obj);
    }

    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSet.ToListAsync();

    public async Task<TEntity> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);

    public void Remove(TEntity obj)
    {
        DbSet.Remove(obj);
    }

    public void Update(TEntity obj)
    {
        DbSet.Update(obj);
    }

    public void Dispose()
    {
        Db.Dispose();
    }
}
