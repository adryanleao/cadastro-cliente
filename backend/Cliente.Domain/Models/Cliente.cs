using Cliente.Domain.Core;

namespace Cliente.Domain.Models;

public class Cliente : ModelBase
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public Endereco Endereco { get; private set; }

    //constructor for EF
    public Cliente()
    {
    }

    public Cliente(
        string nome,
        string email,
        DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
    }
}
