using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWebApp.Dto;
using ProductWebApp.Services;

namespace ProductWebApp.Pages
{
    public class AddProductModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly BrandService _brandService;
        private readonly SizeService _sizeService;
        

        [BindProperty]
        public ProductRegistrationForm ProductForm { get; set; } = new();
        public List<CategoryEntity> Categories { get; set; } = [];
        public List<BrandEntity> Brands { get; set; } = [];
        public List<SizeEntity> Sizes { get; set; } = [];

        public AddProductModel(ProductService productService, CategoryService categoryService, SizeService sizeService, BrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _sizeService = sizeService;
            
        }

        public async Task OnGetAsync()
        {

            Categories = await _categoryService.GetAllCategoriesAsync();
            Brands = await _brandService.GetAllBrandsAsync();
            Sizes = await _sizeService.GetAllSizesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Brands = await _brandService.GetAllBrandsAsync();
                Categories = await _categoryService.GetAllCategoriesAsync();
                Sizes = await _sizeService.GetAllSizesAsync();
                return Page();
            }

            bool success = await _productService.AddproductAsync(ProductForm);
            if (!success)
            {
                ModelState.AddModelError("", "Something went wrong when creating product.");
                return Page();
            }

            return RedirectToPage("/Index"); 
        }
    }
}
