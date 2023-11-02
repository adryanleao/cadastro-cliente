namespace Cliente.Domain.Commands.Validations;

public class AtualizarClienteCommandValidation : ClienteValidation<AtualizarClienteCommand>
{
    public AtualizarClienteCommandValidation()
    {
        ValidateEmail();
        ValidateNome();
        ValidateIdade();
        ValidateCep();
    }
}
