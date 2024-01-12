using MultiShop.Models.Common;

namespace MultiShop.Models;

public class Slider : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ButtonTitle { get; set; }
    public string ImagePath { get; set; }
}
