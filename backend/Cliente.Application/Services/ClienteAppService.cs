﻿using System.Linq.Expressions;
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
    private readonly IClienteRepository _clienteRepository;
    private readonly IMediatorHandler Bus;

    public ClienteAppService(IMapper mapper,
                             IClienteRepository clienteRepository,
                             IMediatorHandler bus)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
        Bus = bus;
    }

    public Task<IEnumerable<ClienteViewModel>> FindAsync(Expression<Func<ClienteViewModel, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.GetByIdIncludeEnderecoAsync());
    }

    public async Task<ClienteViewModel> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ClienteViewModel>(await _clienteRepository.GetByIdAsync(id));
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
