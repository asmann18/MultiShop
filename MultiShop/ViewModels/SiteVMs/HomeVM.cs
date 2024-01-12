namespace MultiShop.ViewModels;

public record HomeVM
{
   public List<SliderGetVM> Sliders { get; set; }
   public List<ServiceGetVM> Services { get; set; }
}
