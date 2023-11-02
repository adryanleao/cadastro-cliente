using MediatR;

namespace Cliente.Domain.Events;

public class ClienteEventHandler : 
            INotificationHandler<ClienteAtualizadoEvent>,
            INotificationHandler<ClienteRegistradoEvent>,
            INotificationHandler<ClienteRemovidoEvent>
{
    public Task Handle(ClienteAtualizadoEvent notification, CancellationToken cancellationToken)
    {
        // Dispara outro processo 
        return Task.CompletedTask;
    }

    public Task Handle(ClienteRemovidoEvent notification, CancellationToken cancellationToken)
    {
        // Dispara outro processo 
        return Task.CompletedTask;
    }

    public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
    {
        // Dispara outro processo 
        return Task.CompletedTask;
    }
}
