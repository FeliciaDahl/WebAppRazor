using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace ProductWebApp.Services;

public class SizeService(ISizeRepository sizeRepository)
{
    private readonly ISizeRepository _sizeRepository = sizeRepository;

    public async Task<List<SizeEntity>> GetAllSizesAsync()
    {
        return await _sizeRepository.GetAllAsync();
    }

}
