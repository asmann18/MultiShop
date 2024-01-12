namespace MultiShop.ViewModels
{
    public record ServicePutVM
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string IconPath { get; init; }
        public string? NewIconPath { get; init; }
    }
}
