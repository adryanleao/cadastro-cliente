using Models = Cliente.Domain.Models;

namespace Cliente.Domain.Interfaces;

public interface IClienteRepository : IRepository<Models.Cliente>
{
    Task<Models.Cliente> GetByEmailAsync(string email);
}
