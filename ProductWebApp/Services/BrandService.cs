using Data.Entities;
using Data.Interfaces;

namespace ProductWebApp.Services;

public class BrandService(IBrandRepository brandRepository)
{

    private readonly IBrandRepository _brandRepository = brandRepository;

    public async Task<List<BrandEntity>> GetAllBrandsAsync()
    {
        return await _brandRepository.GetAllAsync();
    }
}


