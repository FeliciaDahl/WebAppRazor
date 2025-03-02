
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProductSizeRepository(DataContext context) : BaseRepository<ProductSizeEntity>(context) , IProductSizeRepository
{
}
