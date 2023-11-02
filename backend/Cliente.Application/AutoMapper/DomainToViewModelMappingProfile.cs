using AutoMapper;
using Cliente.Application.ViewModels;
using Cliente.Domain.Models;
using Models = Cliente.Domain.Models;

namespace Cliente.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Models.Cliente, ClienteViewModel>()
            .ForMember(dst => dst.Nome, map => map.MapFrom(src => src.Nome))
            .ForMember(dst => dst.Email, map => map.MapFrom(src => src.Email))
            .ForMember(dst => dst.DataNascimento, map => map.MapFrom(src => src.DataNascimento))
            .ForMember(dst => dst.Cep, map => map.MapFrom(src => src.Endereco.Cep))
            .ForMember(dst => dst.Logradouro, map => map.MapFrom(src => src.Endereco.Logradouro))
            .ForMember(dst => dst.Complemento, map => map.MapFrom(src => src.Endereco.Complemento))
            .ForMember(dst => dst.Bairro, map => map.MapFrom(src => src.Endereco.Bairro))
            .ForMember(dst => dst.Localidade, map => map.MapFrom(src => src.Endereco.Localidade))
            .ForMember(dst => dst.Uf, map => map.MapFrom(src => src.Endereco.Uf))
            .ForMember(dst => dst.Ibge, map => map.MapFrom(src => src.Endereco.Ibge))
            .ForMember(dst => dst.Gia, map => map.MapFrom(src => src.Endereco.Gia))
            .ForMember(dst => dst.Ddd, map => map.MapFrom(src => src.Endereco.Ddd))
            .ForMember(dst => dst.Siafi, map => map.MapFrom(src => src.Endereco.Siafi));

        CreateMap<Endereco, EnderecoViewModel>();
    }
}