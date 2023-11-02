using System.Linq.Expressions;
using AutoMapper;
using Cliente.Application.Interfaces;
using Cliente.Application.ViewModels;
using Cliente.Domain.Commands;
using Cliente.Domain.Core;
using Cliente.Domain.Interfaces;
using FluentValidation.Results;

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

    public Task<IEnumerable<ClienteViewModel>> FindAsync(Expression<Func<ClienteViewModel, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteReadOnlyRepository.GetAllAsync());
    }

    public async Task<ClienteViewModel> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ClienteViewModel>(await _clienteReadOnlyRepository.GetByIdAsync(id));
    }

    public async Task<ValidationResult> RegisterAsync(ClienteViewModel clienteViewModel)
    {
        var registerCommand = _mapper.Map<RegistrarClienteCommand>(clienteViewModel);
        return await Bus.SendCommand(registerCommand);
    }

    public async Task<ValidationResult> RemoveByIdAsync(Guid id)
    {
        var removeCommand = new RemoverClienteCommand(id);
        return await Bus.SendCommand(removeCommand);
    }

    public async Task<ValidationResult> UpdateAsync(ClienteViewModel clienteViewModel)
    {
        var updateCommand = _mapper.Map<AtualizarClienteCommand>(clienteViewModel);
        return await Bus.SendCommand(updateCommand);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
