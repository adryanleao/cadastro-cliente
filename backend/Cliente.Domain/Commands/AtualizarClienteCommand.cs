using Cliente.Domain.Commands.Validations;

namespace Cliente.Domain.Commands;

public class AtualizarClienteCommand : ClienteCommand
{
    public AtualizarClienteCommand(
        string nome,
        string email,
        DateTime dataNascimento,
        string cep,
        string logradouro,
        string complemento,
        string bairro,
        string localidade,
        string uf,
        string ibge,
        string gia,
        string ddd,
        string siafi)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
        Cep = cep;
        Logradouro = logradouro;
        Complemento = complemento;
        Bairro = bairro;
        Localidade = localidade;
        Uf = uf;
        Ibge = ibge;
        Gia = gia;
        Ddd = ddd;
        Siafi = siafi;
    }
    public override bool IsValid()
    {
        ValidationResult = new AtualizarClienteCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
