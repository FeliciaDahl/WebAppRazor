using Data.Entities;

namespace Data.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllWithDetailsAsync();
        Task<ProductEntity?> GetByIdWithDetailsAsync(int id);
    }
}