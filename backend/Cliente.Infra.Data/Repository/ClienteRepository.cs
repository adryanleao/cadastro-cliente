using Cliente.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models = Cliente.Domain.Models;

namespace Cliente.Infra.Data.Repository;

public class ClienteRepository : Repository<Models.Cliente>, IClienteRepository
{
    public ClienteRepository(ClienteContext db) : base(db)
    {
    }

    public Models.Cliente GetByEmail(string email)
    {
        var retorno = DbSet.AsNoTracking()
            .FirstOrDefault(c => c.Email == email);
        return retorno;
    }
}
