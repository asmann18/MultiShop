namespace MultiShop.ViewModels;

public record SliderGetVM
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string ButtonTitle { get; init; }
    public string ImagePath { get; init; }
}
