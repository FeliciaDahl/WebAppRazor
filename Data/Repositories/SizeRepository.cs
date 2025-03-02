
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class SizeRepository(DataContext context) : BaseRepository<SizeEntity>(context) , ISizeRepository
{
}
