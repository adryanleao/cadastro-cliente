using Cliente.Domain.Core;
using Cliente.Domain.Core.Events;
using MediatR;

namespace Cliente.Infra.CrossCutting.Bus;

public class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;

    public InMemoryBus(IMediator mediator) => _mediator = mediator;

    public Task RaiseEvent<T>(T @event) where T : Event
    {
        return _mediator.Publish(@event);
    }

    public Task SendCommand<T>(T command) where T : Command
    {
        return _mediator.Send(@command);
    }
}
