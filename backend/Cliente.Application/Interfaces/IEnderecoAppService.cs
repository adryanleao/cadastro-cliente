namespace Cliente.Application.Interfaces;

public interface IEnderecoAppService : IDisposable
{
    Task<EnderecoViewModel> GetByCepAsync(string cep);
}
