using ProductWebApp.Models;
using System.Diagnostics;

namespace ProductWebApp.Services;

public class ProductService
{

    private readonly List<Product> _products;

    //public ProductService()
    //{
    //    _products = new List<Product>
    //    {
    //        new() { Id = 1, ProductName = "White Oversize T-shirt", Price = 199.99m},
    //        new() { Id = 2, ProductName = "Joggers", Price = 599.99m },
    //        new() { Id = 3, ProductName = "Black T-shirt", Price = 199.99m },
    //        new() { Id = 4, ProductName = "Slim Jeans", Price = 599.99m },
    //        new() { Id = 5, ProductName = "White Top", Price = 199.99m },
    //        new() { Id = 6, ProductName = "Joggers", Price = 599.99m},
    //        new() { Id = 7, ProductName = "Joggers", Price = 599.99m},
    //        new() { Id = 8, ProductName = "Joggers", Price = 599.99m},
    //        new() { Id = 9, ProductName = "Joggers", Price = 599.99m
    //    };

    //}

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public bool AddProduct(Product product)
    {
        try
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = GetProductById(id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}


