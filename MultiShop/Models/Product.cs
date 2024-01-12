using MultiShop.Models.Common;

namespace MultiShop.Models;

public class Product:BaseAuditableEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string FacebookLink { get; set; }
    public string ImagePath { get; set; }
    public string CategoryId { get; set; }
    public Category Category { get; set; }
}
