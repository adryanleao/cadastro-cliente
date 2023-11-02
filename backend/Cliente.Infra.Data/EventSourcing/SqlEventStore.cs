using Cliente.Domain.Core;
using Cliente.Domain.Core.Events;
using Cliente.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace Cliente.Infra.Data.EventSourcing;

public class SqlEventStore : IEventStore
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public SqlEventStore(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public void Save<T>(T theEvent) where T : Event
    {
        var serializedData = JsonConvert.SerializeObject(theEvent);

        var storedEvent = new StoredEvent(
            theEvent,
            serializedData);

        _eventStoreRepository.Store(storedEvent);
    }
}
