using Cliente.Domain.Core;
using Cliente.Domain.Core.Events;
using FluentValidation.Results;
using MediatR;

namespace Cliente.Infra.CrossCutting.Bus;

public class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;
    private readonly IEventStore _eventStore;

    public InMemoryBus(IEventStore eventStore, IMediator mediator)
    {
        _mediator = mediator;
        _eventStore = eventStore;
    }

    public async Task RaiseEvent<T>(T @event) where T : Event
    {
        if (!@event.MessageType.Equals("DomainNotification"))
            _eventStore?.Save(@event);

        await _mediator.Publish(@event);
    }

    public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
}
