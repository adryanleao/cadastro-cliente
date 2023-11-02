using Cliente.Domain.Core.Events;
using FluentValidation.Results;
using MediatR;

namespace Cliente.Domain.Core;

public interface IMediatorHandler
{
    // Task SendCommand<T>(T command) where T : Command;
    // Task RaiseEvent<T>(T @event) where T : Event;

    Task RaiseEvent<T>(T @event) where T : Event;

    Task<ValidationResult> SendCommand<T>(T command) where T : Command;
}
