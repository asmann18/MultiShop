namespace MultiShop.ViewModels
{
    public record SliderPutVM
    {
        public int Id { get; set; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string ButtonTitle { get; init; }
        public string ImagePath { get; init; }
        public IFormFile? Image { get; init; }
    }
}
