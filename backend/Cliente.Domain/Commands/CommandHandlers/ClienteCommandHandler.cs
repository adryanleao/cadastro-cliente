
using Cliente.Domain.Core;
using Cliente.Domain.Core.Notifications;
using Cliente.Domain.Events;
using Cliente.Domain.Interfaces;
using MediatR;
using Models = Cliente.Domain.Models;

namespace Cliente.Domain.Commands.CommandHandlers;

public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegistrarClienteCommand>,
        IRequestHandler<RemoverClienteCommand>,
        IRequestHandler<AtualizarClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMediatorHandler Bus;
    public ClienteCommandHandler(IClienteRepository clienteRepository,
                                 IUnitOfWork uow,
                                 IMediatorHandler bus,
                                 INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
    {
        Bus = bus;
        _clienteRepository = clienteRepository;
    }

    public Task<Unit> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Unit.Value);
        }

        var cliente = new Models.Cliente(Guid.NewGuid(),
                                         request.Nome,
                                         request.Email,
                                         request.DataNascimento,
                                         new Models.Endereco(request.Cep, request.Logradouro, request.Complemento, request.Bairro, request.Localidade, request.Uf, request.Ibge, request.Gia, request.Ddd, request.Siafi));

        if (_clienteRepository.GetByEmail(cliente.Email) != null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "Já existe um cliente com esse e-mail."));
            return Task.FromResult(Unit.Value);
        }

        _clienteRepository.Add(cliente);

        if (Commit())
        {
            Bus.RaiseEvent(new ClienteRegistradoEvent(cliente.Id, cliente.Nome, cliente.Email));
        }

        return Task.FromResult(Unit.Value);
    }

    public Task<Unit> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(Unit.Value);
            }

            var cliente = new Models.Cliente(Guid.NewGuid(),
                                         request.Nome,
                                         request.Email,
                                         request.DataNascimento,
                                         new Models.Endereco(request.Cep, request.Logradouro, request.Complemento, request.Bairro, request.Localidade, request.Uf, request.Ibge, request.Gia, request.Ddd, request.Siafi));

            var existingCliente = _clienteRepository.GetByEmail(cliente.Email);

            if (existingCliente != null && existingCliente.Id != cliente.Id)
            {
                if (!existingCliente.Equals(cliente))
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "Ja existe um Cliente com esse e-mail."));
                    return Task.FromResult(Unit.Value);
                }
            }

            _clienteRepository.Update(cliente);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteAtualizadoEvent(cliente.Id, cliente.Nome, cliente.Email));
            }

            return Task.FromResult(Unit.Value);
    }

    public Task<Unit> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            Task.FromResult(Unit.Value);
        }
        var cliente = _clienteRepository.GetByEmail(request.Email);
        if (cliente == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "Cliente não encontrado"));
            return Task.FromResult(Unit.Value);
        }
        _clienteRepository.Remove(cliente.Id);

        if (Commit())
        {
            Bus.RaiseEvent(new ClienteRemovidoEvent(cliente.Id, cliente.Nome, cliente.Email));
        }
        return Task.FromResult(Unit.Value);
    }
}
