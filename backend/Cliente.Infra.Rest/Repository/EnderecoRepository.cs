using Cliente.Domain.Interfaces;
using Models = Cliente.Domain.Models;
using Refit;

namespace Cliente.Infra.Rest.Repository;

public class EnderecoRepository : IEnderecoRepository
{

    public async Task<Models.Endereco> GetByCepAsync(string cep)
    {
        var endereco = RestService.For<IEnderecoAPI>("https://viacep.com.br/ws");
        var retorno = await endereco.GetEndereco(cep);
        return new Models.Endereco(retorno.cep, retorno.logradouro, retorno.complemento, retorno.bairro, retorno.localidade, retorno.uf, retorno.ibge, retorno.gia, retorno.ddd, retorno.siafi);
    }
}

public interface IEnderecoAPI
{
    [Get("/{cep}/json/")]
    Task<EnderecoRefit> GetEndereco(string cep);
}

public class EnderecoRefit
{
    public string cep { get; set; }
    public string logradouro { get; set; }
    public string complemento { get; set; }
    public string bairro { get; set; }
    public string localidade { get; set; }
    public string uf { get; set; }
    public string ibge { get; set; }
    public string gia { get; set; }
    public string ddd { get; set; }
    public string siafi { get; set; }
}
