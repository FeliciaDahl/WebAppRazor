
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class BrandRepository(DataContext context) : BaseRepository<BrandEntity>(context) , IBrandRepository
{
}
