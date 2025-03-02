
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class SizeEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName ="nvarchar(5)")]
    public string ProductSize { get; set; } = null!;

    public virtual ICollection<ProductSizeEntity> ProductSizes { get; set; } = [];
}
