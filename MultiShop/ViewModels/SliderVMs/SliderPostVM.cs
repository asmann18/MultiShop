namespace MultiShop.ViewModels;

public record SliderPostVM
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string ButtonTitle { get; init; }
    public IFormFile Image { get; init; }
}
