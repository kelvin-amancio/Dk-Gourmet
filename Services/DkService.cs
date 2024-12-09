using DkGourmet.Data;
using DkGourmet.Entites;
using DkGourmet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DkGourmet.Services;

public class DkService(AppDbContext context) : IDkService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Produto>> GetAllAsync() =>
         await _context.Produto.AsNoTracking().ToListAsync();
    
    public async Task<Produto?> GetByIdAsync(string id) =>
         await _context.Produto.FindAsync(id);

    public async Task AddAsync(Produto produto)
    {
         await _context.Produto.AddAsync(produto);
         await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
         _context.Produto.Update(produto);
         await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(string id)
    {
         var produto = await _context.Produto.FindAsync(id);

         if (produto is not null)
         { 
              _context.Produto.Remove(produto);
              await _context.SaveChangesAsync();
         }
    }
}