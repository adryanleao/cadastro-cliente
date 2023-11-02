namespace Cliente.Domain.Interfaces;

public interface IEnderecoRepository
{
    Task<Models.Endereco> GetByCepAsync(string cep);
}
