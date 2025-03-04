
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context), IProductRepository
{

    public async Task<List<ProductEntity>> GetAllWithDetailsAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.ProductSizes)
                .ThenInclude(ps => ps.Size)
            .ToListAsync();
    }

    public async Task<ProductEntity?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.ProductSizes)
                .ThenInclude(ps => ps.Size)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

}
