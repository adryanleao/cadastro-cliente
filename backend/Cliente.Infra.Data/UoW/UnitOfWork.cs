using Cliente.Domain.Interfaces;

namespace Cliente.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClienteContext _context;

    public UnitOfWork(ClienteContext context)
    {
        _context = context;
    }
    public bool Commit()
    {
        return _context.SaveChanges() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
