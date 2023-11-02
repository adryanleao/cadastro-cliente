using Cliente.Domain.Core;

namespace Cliente.Domain.Commands;

public abstract class ClienteCommand : Command
{
    public Guid Id { get; protected set; }
    public string Nome { get; protected set; }
    public string Email { get; protected set; }
    public DateTime DataNascimento { get; protected set; }
    public string Cep { get; protected set; }
    public string Logradouro { get; protected set; }
    public string Complemento { get; protected set; }
    public string Bairro { get; protected set; }
    public string Localidade { get; protected set; }
    public string Uf { get; protected set; }
    public string Ibge { get; protected set; }
    public string Gia { get; protected set; }
    public string Ddd { get; protected set; }
    public string Siafi { get; protected set; }
}