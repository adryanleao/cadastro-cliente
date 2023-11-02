using System.Linq.Expressions;
using Cliente.Application.ViewModels;
using FluentValidation.Results;

namespace Cliente.Application.Interfaces;

public interface IClienteAppService : IDisposable
{
    Task<ValidationResult> RegisterAsync(ClienteViewModel clienteViewModel);
    Task<IEnumerable<ClienteViewModel>> GetAllAsync();
    Task<ClienteViewModel> GetByIdAsync(Guid id);
    Task<IEnumerable<ClienteViewModel>> FindAsync(Expression<Func<ClienteViewModel, bool>> predicate);
    Task<ValidationResult> UpdateAsync(ClienteViewModel clienteViewModel);
    Task<ValidationResult> RemoveByIdAsync(Guid id);
}
