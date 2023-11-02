using Cliente.Application.Interfaces;
using Cliente.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Services.Api.Controller;

[Route("api/")]
public class ClienteController : ApiController
{
    private readonly IClienteAppService _clienteAppService;

    public ClienteController(
        IClienteAppService clienteAppService) 
    {
        _clienteAppService = clienteAppService;
    }

    [HttpGet]
    [Route("clientes")]
    public async Task<IEnumerable<ClienteViewModel>> Get()
    {
        return await _clienteAppService.GetAllAsync();
    }

    [HttpGet]
    [Route("clientes/{id:guid}")]
    public async Task<ClienteViewModel> Get(Guid id)
    {
        return await _clienteAppService.GetByIdAsync(id);
    }

    [HttpPost]
    [Route("clientes")]
    public async Task<IActionResult> Post([FromBody] ClienteViewModel clienteViewModel)
    {
        return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clienteAppService.RegisterAsync(clienteViewModel));
    }

    [HttpPut]
    [Route("clientes")]
    public async Task<IActionResult> Put([FromBody] ClienteViewModel clienteViewModel)
    {
        return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clienteAppService.UpdateAsync(clienteViewModel));
    }

    [HttpDelete]
    [Route("clientes/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return CustomResponse(await _clienteAppService.RemoveByIdAsync(id));
    }
}
