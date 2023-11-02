using Cliente.Application.Interfaces;
using Cliente.Application.ViewModels;
using Cliente.Domain.Core;
using Cliente.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Services.Api.Controller;

[Route("api/")]
public class ClienteController : ApiController
{
    private readonly IClienteAppService _clienteAppService;

    public ClienteController(
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        IClienteAppService clienteAppService) : base(notifications, mediator)
    {
        _clienteAppService = clienteAppService;
    }

    [HttpGet]
    [Route("clientes")]
    public IActionResult Get()
    {
        return Response(_clienteAppService.GetAll());
    }

    [HttpGet]
    [Route("clientes/{email}")]
    public IActionResult Get(string email)
    {
        var clienteViewModel = _clienteAppService.GetByEmail(email);
        return Response(clienteViewModel);
    }

    [HttpPost]
    [Route("clientes")]
    public IActionResult Post([FromBody] ClienteViewModel clienteViewModel)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(clienteViewModel);
        }
        _clienteAppService.Register(clienteViewModel);
        return Response(clienteViewModel);
    }

    [HttpPut]
    [Route("clientes")]
    public IActionResult Put([FromBody] ClienteViewModel clienteViewModel)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(clienteViewModel);
        }
        _clienteAppService.Update(clienteViewModel);
        return Response(clienteViewModel);
    }

    [HttpDelete]
    [Route("clientes/{email}")]
    public IActionResult Delete(string email)
    {
        _clienteAppService.RemoveByEmail(email);
        return Response();
    }
}
