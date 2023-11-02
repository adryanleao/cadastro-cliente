using Cliente.Domain.Commands.Validations;

namespace Cliente.Domain.Commands;

public class RemoverClienteCommand : ClienteCommand
{
    public RemoverClienteCommand(string email)
        {
            Email = email;
            AggregateId = Guid.NewGuid();
        }
    public override bool IsValid()
    {
        ValidationResult = new RemoverClienteCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
