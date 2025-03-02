using System.ComponentModel.DataAnnotations;


namespace ProductWebApp.Models;

public class Product
{
    public int Id { get; set; }
  
    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string CategoryName { get; set; } = null!;
    public string ProductSize { get; set; } = null!;

}



