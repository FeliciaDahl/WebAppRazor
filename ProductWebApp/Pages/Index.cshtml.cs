
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWebApp.Models;
using ProductWebApp.Services;

namespace ProductWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ProductService _productService;

    public List<Product> Products { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger, ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public void OnGet()
    {
        Products = _productService.GetAllProducts();
    }
}
