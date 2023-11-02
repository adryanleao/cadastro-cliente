using Cliente.Domain.Core;

namespace Cliente.Domain.Models;

public class Endereco : ModelBase
{
    public string Cep { get; private set; }
    public string Logradouro { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Localidade { get; private set; }
    public string Uf { get; private set; }
    public string Ibge { get; private set; }
    public string Gia { get; private set; }
    public string Ddd { get; private set; }
    public string Siafi { get; private set; }
    public Cliente Cliente { get; private set; }
    public int ClienteRefId { get; set; }
    
    //constructor for EF
    public Endereco()
    {
    }

    public Endereco(
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
}
