using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace ProductWebApp.Services;

public class CategoryService(ICategoryRepository categoryRepository)
{

    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<CategoryEntity>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }
}


