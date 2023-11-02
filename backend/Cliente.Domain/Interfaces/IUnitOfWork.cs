namespace Cliente.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
}
