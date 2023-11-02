using Cliente.Application;
using Cliente.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Services.Api.Controller;

[Route("api/")]
public class EnderecoController : ApiController
{
    private readonly IEnderecoAppService _clienteAppService;

    public EnderecoController(IEnderecoAppService clienteAppService)
    {
        _clienteAppService = clienteAppService;
    }

    [HttpGet]
    [Route("endereco/{cep}")]
    public async Task<EnderecoViewModel> Get(string cep)
    {
        return await _clienteAppService.GetByCepAsync(cep);
    }
}
