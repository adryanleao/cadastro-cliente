namespace Cliente.Domain.Commands.Validations;

public class RegistrarClienteCommandValidation: ClienteValidation<RegistrarClienteCommand>
{
    public RegistrarClienteCommandValidation()
    {
        ValidateEmail();
        ValidateNome();
        ValidateIdade();
        ValidateCep();
    }
}