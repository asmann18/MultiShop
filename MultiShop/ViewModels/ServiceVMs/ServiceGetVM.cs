namespace MultiShop.ViewModels;

public record ServiceGetVM
{
    public int Id { get; init; }
    public string Name { get; init; }
   
    public string IconPath { get; init; }
}
