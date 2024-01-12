using AutoMapper;
using MultiShop.Models;
using MultiShop.ViewModels;

namespace MultiShop.AutoMappers;

public class SliderAutoMapper:Profile
{
    public SliderAutoMapper()
    {
        CreateMap<Slider, SliderGetVM>().ReverseMap();
        CreateMap<Slider, SliderPostVM>().ReverseMap();
        CreateMap<Slider, SliderPutVM>().ForMember(x=>x.ImagePath,s=>s.Ignore()).ReverseMap();
        CreateMap<SliderGetVM, SliderPutVM>().ReverseMap();
    }
}
