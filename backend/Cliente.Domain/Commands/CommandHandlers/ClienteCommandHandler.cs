
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
            AddError("Já existe um cliente com esse email");
            return ValidationResult;
        }
        cliente.AddDomainEvent(new ClienteRegistradoEvent(cliente.Id, cliente.Nome, cliente.Email));

        _clienteRepository.Add(cliente);

        return await Commit(_clienteRepository.UnitOfWork);
    }

    // public Task<Unit> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    // {
    //     if (!request.IsValid())
    //         {
    //             NotifyValidationErrors(request);
    //             return Task.FromResult(Unit.Value);
    //         }

    //         var cliente = new Models.Cliente(Guid.NewGuid(),
    //                                      request.Nome,
    //                                      request.Email,
    //                                      request.DataNascimento,
    //                                      new Models.Endereco(request.Cep, request.Logradouro, request.Complemento, request.Bairro, request.Localidade, request.Uf, request.Ibge, request.Gia, request.Ddd, request.Siafi));

    //         var existingCliente = _clienteRepository.GetByEmail(cliente.Email);

    //         if (existingCliente != null && existingCliente.Id != cliente.Id)
    //         {
    //             if (!existingCliente.Equals(cliente))
    //             {
    //                 Bus.RaiseEvent(new DomainNotification(request.MessageType, "Ja existe um Cliente com esse e-mail."));
    //                 return Task.FromResult(Unit.Value);
    //             }
    //         }

    //         _clienteRepository.Update(cliente);

    //         if (Commit())
    //         {
    //             Bus.RaiseEvent(new ClienteAtualizadoEvent(cliente.Id, cliente.Nome, cliente.Email));
    //         }

    //         return Task.FromResult(Unit.Value);
    // }

    // public Task<Unit> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
    // {
    //     if (!request.IsValid())
    //     {
    //         NotifyValidationErrors(request);
    //         Task.FromResult(Unit.Value);
    //     }
    //     var cliente = _clienteRepository.GetByEmail(request.Email);
    //     if (cliente == null)
    //     {
    //         Bus.RaiseEvent(new DomainNotification(request.MessageType, "Cliente não encontrado"));
    //         return Task.FromResult(Unit.Value);
    //     }
    //     _clienteRepository.Remove(cliente.Id);

    //     if (Commit())
    //     {
    //         Bus.RaiseEvent(new ClienteRemovidoEvent(cliente.Id, cliente.Nome, cliente.Email));
    //     }
    //     return Task.FromResult(Unit.Value);
    // }
}
