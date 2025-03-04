namespace ProductWebApp.Dto;

public class ProductRegistrationForm
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public List<int> SelectedSizeIds { get; set; } = [];

    public Dictionary<int, int> SizeQuantities { get; set; } = [];
}
