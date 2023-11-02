using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cliente.Application.Interfaces;
using Cliente.Application.ViewModels;
using Cliente.Domain.Commands;
using Cliente.Domain.Core;
using Cliente.Domain.Interfaces;

namespace Cliente.Application.Services;

public class ClienteAppService : IClienteAppService
{
    private readonly IMapper _mapper;
    private readonly IClienteRepository _clienteReadOnlyRepository;
    private readonly IMediatorHandler Bus;

    public ClienteAppService(IMapper mapper,
                             IClienteRepository clienteReadOnlyRepository,
                             IMediatorHandler bus)
    {
        _mapper = mapper;
        _clienteReadOnlyRepository = clienteReadOnlyRepository;
        Bus = bus;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public IEnumerable<ClienteViewModel> Find(Expression<Func<ClienteViewModel, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ClienteViewModel> GetAll()
    {
        return _clienteReadOnlyRepository.GetAll().ProjectTo<ClienteViewModel>(_mapper.ConfigurationProvider);
    }

    public ClienteViewModel GetByEmail(string email)
    {
        return _mapper.Map<ClienteViewModel>(_clienteReadOnlyRepository.GetByEmail(email));
    }

    public void Register(ClienteViewModel clienteViewModel)
    {
        var registerCommand = _mapper.Map<RegistrarClienteCommand>(clienteViewModel);
        Bus.SendCommand(registerCommand);
    }

    public void RemoveByEmail(string email)
    {
        var removeCommand = new RemoverClienteCommand(email);
        Bus.SendCommand(removeCommand);
    }

    public void Update(ClienteViewModel clienteViewModel)
    {
        var updateCommand = _mapper.Map<AtualizarClienteCommand>(clienteViewModel);
        Bus.SendCommand(updateCommand);
    }
}
