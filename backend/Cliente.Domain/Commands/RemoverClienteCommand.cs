using Cliente.Domain.Commands.Validations;

namespace Cliente.Domain.Commands;

public class RemoverClienteCommand : ClienteCommand
{
    public RemoverClienteCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    public override bool IsValid()
    {
        ValidationResult = new RemoverClienteCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
