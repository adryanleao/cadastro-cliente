using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cliente.Application.ViewModels;

public class ClienteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    [Required(ErrorMessage = "O E-mail é obrigatorio")]
    [EmailAddress]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
    [DisplayName("Data de Aniversário")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O Cep é obrigatorio")]
    [DisplayName("Cep")]
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string Uf { get; set; }
    public string Ibge { get; set; }
    public string Gia { get; set; }
    public string Ddd { get; set; }
    public string Siafi { get; set; }
}
