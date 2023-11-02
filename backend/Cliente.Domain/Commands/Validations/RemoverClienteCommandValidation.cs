namespace Cliente.Domain.Commands.Validations;

public class RemoverClienteCommandValidation : ClienteValidation<RemoverClienteCommand>
{
    public RemoverClienteCommandValidation()
    {
        ValidateEmail();
    }
}
