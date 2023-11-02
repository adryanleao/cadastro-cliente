using Cliente.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models = Cliente.Domain.Models;

namespace Cliente.Infra.Data.Repository;

public class ClienteRepository : Repository<Models.Cliente>, IClienteRepository
{
    public ClienteRepository(ClienteContext db) : base(db)
    {
    }
    public async Task<Models.Cliente> GetByEmailAsync(string email) => await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
}
