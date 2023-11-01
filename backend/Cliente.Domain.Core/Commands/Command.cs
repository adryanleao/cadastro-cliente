using Cliente.Domain.Core.Events;
using FluentValidation.Results;

namespace Cliente.Domain.Core;

public abstract class Command : Message
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command() => Timestamp = DateTime.Now;

    public abstract bool IsValid();
}
