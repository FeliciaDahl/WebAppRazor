using Data.Entities;
using Data.Interfaces;
using ProductWebApp.Dto;
using ProductWebApp.Models;
using System.Diagnostics;

namespace ProductWebApp.Services;

public class ProductService(IProductRepository productRepository)
{
    private readonly IProductRepository _productRepository = productRepository;


    public async Task<bool> AddproductAsync (ProductRegistrationForm form)
    {
        try
        {
            var product = new ProductEntity
            {
                ProductName = form.ProductName,
                Price = form.Price,
                CategoryId = form.CategoryId,
                ProductSizes = form.SelectedSizeIds.Select(sizeId => new ProductSizeEntity { SizeId = sizeId }).ToList()

            };

            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error adding product: {ex.Message}");
            return false;
        }
    }

    public async Task<List<ProductEntity>> GetAllProductsAsync()
    {
        try
        {
            return await _productRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching products: {ex.Message}");
            return [];
        }
    }

    public async Task<ProductEntity?> GetProductByIdAsync(int id)
    {
        try
        {
            return await _productRepository.FindAsync(p => p.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching product by ID {id}: {ex.Message}");
            return null;
        }
    }
    public async Task<bool> UpdateProductAsync(ProductEntity product)
    {
        try
        {
            _productRepository.Update(product);
            await _productRepository.SaveAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating product: {ex.Message}");
            return false;
        }
    }
    public async Task<bool> DeleteProductAsync(ProductEntity product)
    {
        try
        {
            _productRepository.Delete(product);
            await _productRepository.SaveAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting product: {ex.Message}");
            return false;
        }
    }

}


