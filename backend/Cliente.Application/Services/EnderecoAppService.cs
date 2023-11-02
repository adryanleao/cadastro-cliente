using AutoMapper;
using Cliente.Application.Interfaces;
using Cliente.Domain.Interfaces;

namespace Cliente.Application.Services;

public class EnderecoAppService : IEnderecoAppService
{
    private readonly IMapper _mapper;
    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoAppService(IMapper mapper, IEnderecoRepository enderecoRepository)
    {
        _mapper = mapper;
        _enderecoRepository = enderecoRepository;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<EnderecoViewModel> GetByCepAsync(string cep)
    {
        return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.GetByCepAsync(cep));
    }
}
