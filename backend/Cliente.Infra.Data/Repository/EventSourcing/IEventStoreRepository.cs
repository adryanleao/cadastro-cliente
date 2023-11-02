using Cliente.Domain.Core;

namespace Cliente.Infra.Data.Repository.EventSourcing;

public interface IEventStoreRepository : IDisposable
{
    void Store(StoredEvent theEvent);
    Task<IList<StoredEvent>> All(Guid aggregateId);
}

