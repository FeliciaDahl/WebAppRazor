
namespace Data.Entities;

public class ProductSizeEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public int SizeId { get; set; }
    public SizeEntity Size { get; set; } = null!;

    public int Quantity { get; set; }
}
