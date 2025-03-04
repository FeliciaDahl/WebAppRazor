
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProductEntity
{
    [Key]
    public int Id {get; set;}

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }


    public int CategoryId { get; set;}
    public CategoryEntity Category { get; set; } = null!;

    public int BrandId { get; set; }
    public BrandEntity Brand { get; set; } = null!;

    public virtual ICollection<ProductSizeEntity> ProductSizes { get; set; } = [];

}
