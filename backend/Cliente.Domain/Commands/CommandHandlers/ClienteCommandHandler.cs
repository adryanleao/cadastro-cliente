
using Cliente.Domain.Core;
using Cliente.Domain.Core.Notifications;
using Cliente.Domain.Events;
using Cliente.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using Models = Cliente.Domain.Models;

namespace Cliente.Domain.Commands.CommandHandlers;

public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
// IRequestHandler<RemoverClienteCommand>,
//  IRequestHandler<AtualizarClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ValidationResult> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;
        var cliente = new Models.Cliente(Guid.NewGuid(),
                                         request.Nome,
                                         request.Email,
                                         request.DataNascimento,
                                         new Models.Endereco(request.Cep, request.Logradouro, request.Complemento, request.Bairro, request.Localidade, request.Uf, request.Ibge, request.Gia, request.Ddd, request.Siafi));

        if (await _clienteRepository.GetByEmailAsync(request.Email) != null)
        {
            AddError("Já existe um cliente com esse e-mail cadastrado.");
            return ValidationResult;
        }
        cliente.AddDomainEvent(new ClienteRegistradoEvent(cliente.Id, cliente.Nome, cliente.Email));

        _clienteRepository.Add(cliente);

        return await Commit(_clienteRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;
        var cliente = new Models.Cliente(Guid.NewGuid(),
                                     request.Nome,
                                     request.Email,
                                     request.DataNascimento,
                                     new Models.Endereco(request.Cep, request.Logradouro, request.Complemento, request.Bairro, request.Localidade, request.Uf, request.Ibge, request.Gia, request.Ddd, request.Siafi));

        var existingCliente = await _clienteRepository.GetByEmailAsync(cliente.Email);
        if (existingCliente != null && existingCliente.Id != cliente.Id)
        {
            if (!existingCliente.Equals(cliente))
            {
                AddError("Já existe um cliente com esse e-mail cadastrado.");
                return ValidationResult;
            }
        }
        cliente.AddDomainEvent(new ClienteAtualizadoEvent(cliente.Id, cliente.Nome, cliente.Email));
        _clienteRepository.Update(cliente);

        return await Commit(_clienteRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;
        var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            if (cliente is null)
            {
                AddError("Cliente nao encontrado.");
                return ValidationResult;
            }

            cliente.AddDomainEvent(new ClienteRemovidoEvent(cliente.Id, cliente.Nome, cliente.Email));

            _clienteRepository.Remove(cliente);

            return await Commit(_clienteRepository.UnitOfWork);
    }
}
