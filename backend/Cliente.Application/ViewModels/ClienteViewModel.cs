using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cliente.Application.ViewModels;

public class ClienteViewModel
{
    public string Nome { get; private set; }

    [Required(ErrorMessage = "O E-mail é obrigatorio")]
    [EmailAddress]
    [DisplayName("E-mail")]
    public string Email { get; private set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
    [DisplayName("Data de Aniversário")]
    public DateTime DataNascimento { get; private set; }

    [Required(ErrorMessage = "O Cep é obrigatorio")]
    [DisplayName("Cep")]
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
}
