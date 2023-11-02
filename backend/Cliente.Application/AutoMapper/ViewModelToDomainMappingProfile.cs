using AutoMapper;
using Cliente.Application.ViewModels;
using Cliente.Domain.Commands;

namespace Cliente.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<ClienteViewModel, RegistrarClienteCommand>()
            .ConstructUsing(c => new RegistrarClienteCommand(c.Nome, c.Email, c.DataNascimento, c.Cep, c.Logradouro, c.Complemento, c.Bairro, c.Localidade, c.Uf, c.Ibge, c.Gia, c.Ddd, c.Siafi));
        CreateMap<ClienteViewModel, AtualizarClienteCommand>()
            .ConstructUsing(c => new AtualizarClienteCommand(c.Nome, c.Email,c.DataNascimento, c.Cep, c.Logradouro, c.Complemento, c.Bairro, c.Localidade, c.Uf, c.Ibge, c.Gia, c.Ddd, c.Siafi));
    }
}
