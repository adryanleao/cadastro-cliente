using Cliente.Domain.Core.Events;

namespace Cliente.Domain.Core;

public abstract class ModelBase
{
    private List<Event> _domainEvents;

    public Guid Id { get; set; }

    public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly();

    protected ModelBase()
    {
        Id = Guid.NewGuid();
    }

    public void AddDomainEvent(Event domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<Event>();
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(Event domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public override bool Equals(object obj)
    {
        ModelBase entity = obj as ModelBase;
        if ((object)this == entity)
        {
            return true;
        }

        if ((object)entity == null)
        {
            return false;
        }

        return Id.Equals(entity.Id);
    }

    public static bool operator ==(ModelBase a, ModelBase b)
    {
        if ((object)a == null && (object)b == null)
        {
            return true;
        }

        if ((object)a == null || (object)b == null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(ModelBase a, ModelBase b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() ^ 0x5D) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}
