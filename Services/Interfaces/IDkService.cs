using DkGourmet.Entites;

namespace DkGourmet.Services.Interfaces;

public interface IDkService
{
    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto?> GetByIdAsync(string id);
    Task AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task RemoveAsync(string id);
}