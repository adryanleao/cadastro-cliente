﻿using Cliente.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Infra.Data.Repository.EventSourcing;

public class EventStoreRepository : IEventStoreRepository
{
    private readonly EventStoreSqlContext _context;

    public EventStoreRepository(EventStoreSqlContext context)
    {
        _context = context;
    }

    public async Task<IList<StoredEvent>> All(Guid aggregateId)
    {
        return await (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Store(StoredEvent theEvent)
    {
        _context.StoredEvent.Add(theEvent);
        _context.SaveChanges();
    }
}
