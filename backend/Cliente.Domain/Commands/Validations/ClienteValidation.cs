using FluentValidation;

namespace Cliente.Domain.Commands.Validations;

public class ClienteValidation<T> : AbstractValidator<T> where T : ClienteCommand
{
    protected void ValidateNome()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Voce precisa preencher o nome.")
            .Length(2, 100).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
    }
    protected void ValidateEmail()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Digite um email válido.");
    }
    protected void ValidateIdade()
    {
        RuleFor(c => c.DataNascimento)
            .NotEmpty()
            .Must(IdadeMin)
            .WithMessage("O cliente deve ter mais de 18 anos.");
    }
    protected void ValidateCep()
    {
        RuleFor(c => c.Cep)
            .NotEmpty()
            .WithMessage("Voce precisa preencher o CEP.");
    }

    protected static bool IdadeMin(DateTime dataNascimento)
    {
        return dataNascimento <= DateTime.Now.AddYears(-18);
    }
}
