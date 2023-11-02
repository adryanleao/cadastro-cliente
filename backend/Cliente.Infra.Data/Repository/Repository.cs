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

    public void Add(TEntity obj)
    {
        DbSet.Add(obj);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }

    public TEntity GetById(Guid id)
    {
        return DbSet.Find(id);
    }

    public void Remove(Guid id)
    {
        DbSet.Remove(DbSet.Find(id));
    }

    public int SaveChanges()
    {
        return Db.SaveChanges();
    }

    public void Update(TEntity obj)
    {
        DbSet.Update(obj);
    }

    public void Dispose()
    {
        Db.Dispose();
        GC.SuppressFinalize(this);
    }
}
