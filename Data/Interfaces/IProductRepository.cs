using Data.Entities;

namespace Data.Interfaces
{
    public interface IProductRepository :IBaseRepository<ProductEntity>
    {
        Task<List<ProductEntity>> GetAllWithDetailsAsync();
        Task<ProductEntity?> GetByIdWithDetailsAsync(int id);
    }
}