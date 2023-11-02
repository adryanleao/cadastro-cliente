using System.Linq.Expressions;
using Cliente.Application.ViewModels;

namespace Cliente.Application.Interfaces;

public interface IClienteAppService : IDisposable
{
    void Register(ClienteViewModel clienteViewModel);
    IEnumerable<ClienteViewModel> GetAll();
    ClienteViewModel GetByEmail(string email);
    IEnumerable<ClienteViewModel> Find(Expression<Func<ClienteViewModel, bool>> predicate);
    void Update(ClienteViewModel clienteViewModel);
    void RemoveByEmail(string email);
}
