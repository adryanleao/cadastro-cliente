using Cliente.Domain.Core.Events;

namespace Cliente.Domain.Events;

public class ClienteRemovidoEvent : Event
{
    public ClienteRemovidoEvent(Guid id,
                                     string nome,
                                     string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
}