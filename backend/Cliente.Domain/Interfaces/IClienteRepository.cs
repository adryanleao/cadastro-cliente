using Models = Cliente.Domain.Models;

namespace Cliente.Domain.Interfaces;

public interface IClienteRepository : IRepository<Models.Cliente>
{
    Models.Cliente GetByEmail(string email);
}
